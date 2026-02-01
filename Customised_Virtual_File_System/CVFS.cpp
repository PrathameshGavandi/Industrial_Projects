/*
-------------------------------------------------
 Project Name : Customised Virtual File System
 Language     : C
 Domain       : System Programming
 Author       : Prathamesh Rajendra Gavandi
 Date         : January 2026
 Description  : UNIX-like virtual file system
-------------------------------------------------
*/

////////////////////////////////////////////////////////////////////////////////
//
//  Header File Inclusion
//
////////////////////////////////////////////////////////////////////////////////

#include <stdio.h>
#include <stdlib.h>
// #include<unistd.h>
#include <stdbool.h>
#include <string.h>

////////////////////////////////////////////////////////////////////////////////
//
//  User Defined Macros
//
////////////////////////////////////////////////////////////////////////////////

// Maximum file size that we allow in the project
#define MAXFILESIZE 50

#define MAXOPENFILES 20

#define MAXINODE 5

#define READ 1
#define WRITE 2
#define EXECUTE 4

#define START 0
#define CURRENT 1
#define END 2

#define EXECUTE_SUCCESS 0

#define REGULARFILE 1
#define SPECIALFILE 2

////////////////////////////////////////////////////////////////////////////////
//
//  User Defined Macros for error handling
//
////////////////////////////////////////////////////////////////////////////////

#define ERR_INVALID_PARAMETER -1

#define ERR_NO_INODES -2

#define ERR_FILE_ALREADY_EXIST -3
#define ERR_FILE_NOT_EXIST -4

#define ERR_PERMISSION_DENIED -5

#define ERR_INSUFFICIENT_SPACE -6
#define ERR_INSUFFICIENT_DATA -7

#define ERR_MAX_FILES_OPEN -8

////////////////////////////////////////////////////////////////////////////////
//
//  User Defined Structures
//
////////////////////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////////////////////
//
//  Structure Name :    BootBlock
//  Description :       Holds the information to boot the OS
//
////////////////////////////////////////////////////////////////////////////////

struct BootBlock
{
    char Information[100]; // Dummy Booting character array for information
};

////////////////////////////////////////////////////////////////////////////////
//
//  Structure Name :    SuperBlock
//  Description :       Holds the information about the file system
//
////////////////////////////////////////////////////////////////////////////////

struct SuperBlock // Information of Inode
{
    int TotalInodes; // Total
    int FreeInodes;  // Free
};

////////////////////////////////////////////////////////////////////////////////
//
//  Structure Name :    Inode
//  Description :       Holds the information about the file
//
////////////////////////////////////////////////////////////////////////////////

#pragma pack(1)
struct Inode
{
    char FileName[20];
    int InodeNumber;
    int FileSize;
    int ActualFileSize;
    int FileType;
    int ReferenceCount;
    int Permission;
    char *Buffer;       // data in the file
    struct Inode *next; // Pointer to the next Inode
};

typedef struct Inode INODE;
typedef struct Inode *PINODE;
typedef struct Inode **PPINODE;

////////////////////////////////////////////////////////////////////////////////
//
//  Structure Name :    FileTable
//  Description :       Holds the information about opened file.
//                      It maintains the read/write offsets and access mode
//                      for each opened file instance.
//
//  Members Description :
//      ReadOffset   :   Indicates the current read position in the file.
//                       Used while reading data from the file.
//      WriteOffset  :   Indicates the current write position in the file.
//                       Used while writing data into the file.
//      Mode         :   Specifies the access permission of the file.
//                       1 -> Read
//                       2 -> Write
//                       3 -> Read + Write
//      ptrinode     :   Pointer to the inode structure associated with
//                       this opened file.
//
//  Purpose :           FileTable provides a link between the process
//                      (UAREA) and the inode, enabling file operations
//                      like read, write, and close.
//
//  Author :            Prathamesh Rajendra Gavandi
//  Date :              13/01/2026
//
////////////////////////////////////////////////////////////////////////////////

struct FileTable
{
    int ReadOffset;  // Read from first|from Middle|From Last
    int WriteOffset; // Write from first|from Middle|From Last
    int Mode;
    PINODE ptrinode;
};

typedef FileTable FILETABLE;
typedef FileTable *PFILETABLE;

////////////////////////////////////////////////////////////////////////////////
//
//  Structure Name :    UAREA (User Area)
//  Description :       Holds process specific file information.
//                      It represents the User File Descriptor Table (UFDT)
//                      of a process in the virtual file system.
//
//  Members :
//      ProcessName :   Name of the currently running process.
//      UFDT        :   User File Descriptor Table.
//                      It is an array of pointers to FileTable structures.
//                      Each index represents a file descriptor.
//                      NULL indicates unused file descriptor.
//                      Index 0,1,2 are reserved for STDIN, STDOUT, STDERR.
//
//  Purpose :
//      - Maintains mapping between file descriptor and opened files.
//      - Allows a process to open multiple files simultaneously.
//      - Stores runtime file access information.
//
//  Note :
//      Maximum open files per process is limited by MAXOPENFILES.
//
////////////////////////////////////////////////////////////////////////////////


struct UAREA
{
    char ProcessName[20];
    PFILETABLE UFDT[MAXOPENFILES];
};

////////////////////////////////////////////////////////////////////////////////
//
//  Global Variables / Objects
//  Description :   These global objects represent core components of the
//                  Marvellous CVFS (Custom Virtual File System).
//
//  Objects :
//      bootobj  :   Instance of BootBlock structure.
//                  Stores booting related information of the file system.
//
//      superobj :   Instance of SuperBlock structure.
//                  Maintains information about total and free inodes.
//
//      uareaobj :   Instance of UAREA structure.
//                  Represents process specific User File Descriptor Table (UFDT).
//
//      head     :   Head pointer of the Disk Inode List Block (DILB).
//                  It is a linked list of all Inodes in the system.
//                  Used to traverse, allocate and manage files.
//
//  Purpose :
//      - Provides centralized access to file system metadata.
//      - Simulates OS-level global kernel data structures.
//      - Ensures consistent file management across the CVFS.
//
////////////////////////////////////////////////////////////////////////////////

BootBlock bootobj;
SuperBlock superobj;
UAREA uareaobj;

PINODE head = NULL;

////////////////////////////////////////////////////////////////////////////////
//
//  Function Name : InitialiseUAREA
//  Description   : Initializes the UAREA structure by setting the process
//                  name and initializing all UFDT entries to NULL.
//  Author        : Prathamesh Rajendra Gavandi
//  Date          : 13/01/2026
//
//  Input         : None
//  Output        : None
//  Return Value  : void
//
//  Purpose       :
//      - Prepares the User Area for file operations.
//      - Simulates OS-level per-process file descriptor table initialization.
//
////////////////////////////////////////////////////////////////////////////////


void InitialiseUAREA()
{
    strcpy(uareaobj.ProcessName, "Myexe");

    int i = 0;

    for (i = 0; i < MAXOPENFILES; i++)
    {
        uareaobj.UFDT[i] = NULL; // It Sets all pointer variables to NULL (MAXOPENFILES [20])
    }
    printf("Marvellous CVFS : UAREA gets initialised successfully\n");
}

////////////////////////////////////////////////////////////////////////////////
//
//  Function Name : InitialiseSuperBlock
//  Description   : Initializes the SuperBlock structure by setting
//                  total and free inode counts.
//  Author        : Prathamesh Rajendra Gavandi
//  Date          : 13/01/2026
//
//  Input         : None
//  Output        : Message on console
//  Return Value  : void
//
//  Purpose       :
//      - Initializes filesystem metadata.
//      - Keeps track of inode availability in CVFS.
//
////////////////////////////////////////////////////////////////////////////////


void InitialiseSuperBlock()
{
    superobj.TotalInodes = MAXINODE;
    superobj.FreeInodes = MAXINODE;

    printf("Marvellous CVFS : Super block gets initialised successfully\n");
}

////////////////////////////////////////////////////////////////////////////////
//
//  Function Name : CreateDILB
//  Description   : Creates Disk Inode List Block (DILB) by
//                  dynamically allocating and linking all inode structures.
//
//  Author        : Prathamesh Rajendra Gavandi
//  Date          : 13/01/2026
//
//  Input         : None
//  Output        : None
//  Return Value  : void
//
//  Purpose       :
//      - Initializes inode linked list used by CVFS.
//      - Prepares inode pool for file creation operations.
//
////////////////////////////////////////////////////////////////////////////////

void CreateDILB()
{
    int i = 1;
    PINODE newn = NULL;
    PINODE temp = head;

    for (i = 1; i <= MAXINODE; i++)
    {
        newn = (PINODE)malloc(sizeof(INODE));

        strcpy(newn->FileName, "\0");
        newn->InodeNumber = i;
        newn->FileSize = 0;
        newn->ActualFileSize = 0;
        newn->FileType = 0;
        newn->ReferenceCount = 0;
        newn->Permission = 0;
        newn->Buffer = NULL;
        newn->next = NULL;

        if (temp == NULL) // LL is empty
        {
            head = newn;
            temp = head;
        }
        else // LL Contains atleast 1 node
        {
            temp->next = newn;
            temp = temp->next;
        }
    }

    printf("Marvellous CVFS : DILB created successfully\n");
}

////////////////////////////////////////////////////////////////////////////////
//
//  Function Name : StartAuxiliaryDataInitialization
//  Description   : Invokes all functions required to initialize
//                  auxiliary data structures of CVFS.
//
//  Author        : Prathamesh Rajendra Gavandi
//  Date          : 13/01/2026
//
//  Input         : None
//  Output        : None
//  Return Value  : void
//
//  Purpose       :
//      - Initializes BootBlock, SuperBlock, UAREA and DILB.
//      - Prepares CVFS environment before performing file operations.
//
////////////////////////////////////////////////////////////////////////////////


void StartAuxillaryDataInitilisation()
{
    strcpy(bootobj.Information, "Booting process of Marvellous CVFS is done\n");

    printf("%s", bootobj.Information);

    InitialiseSuperBlock();

    CreateDILB();

    InitialiseUAREA();

    printf("Marvellous CVFS : Auxillary data initialise successfully\n");
}

////////////////////////////////////////////////////////////////////////////////
//
//  Function Name : DisplayHelp
//  Description   : Displays the help menu containing available
//                  commands of Marvellous CVFS.
//  Author        : Prathamesh Rajendra Gavandi
//  Date          : 14/01/2026
//
//  Input         : None
//  Output        : Displays help information on console
//  Return Value  : void
//
////////////////////////////////////////////////////////////////////////////////


void DisplayHelp()
{
    printf("--------------------------------------------------------------\n");
    printf("----------------- Marvellous CVFS help page ------------------\n");
    printf("--------------------------------------------------------------\n");

    printf("man     : It is used to display manual page\n");
    printf("clear   : It is used to clear the terminal\n");
    printf("creat   : It is used to create new file\n");
    printf("write   : It is used to write the data into the file\n");
    printf("read    : It is used to read the data from the file\n");
    printf("stat    : It is used to display statistical information\n");
    printf("unlink  : It is used to delete the file\n");
    printf("exit    : It is used to terminate Marvellous CVFS\n");

    printf("--------------------------------------------------------------\n");
}

////////////////////////////////////////////////////////////////////////////////
//
//  Function Name : ManPageDisplay
//  Description   : Displays the manual page for a given command
//  Author        : Prathamesh Rajendra Gavandi
//  Date          : 14/01/2026
//
//  Input         : Name[] - Name of the command for which manual is requested
//  Output        : Displays information about the command on the console
//  Return Value  : void
//
////////////////////////////////////////////////////////////////////////////////


void ManPageDisplay(char Name[])
{
    if (strcmp("ls", Name) == 0)
    {
        printf("About : Lists the names of all files in CVFS\n");
        printf("Usage : ls\n");
    }
    else if (strcmp("man", Name) == 0)
    {
        printf("About : Displays the manual page for commands\n");
        printf("Usage : man command_name\n");
        printf("command_name : Name of the command\n");
    }
    else if (strcmp("exit", Name) == 0)
    {
        printf("About : Terminates Marvellous CVFS\n");
        printf("Usage : exit\n");
    }
    else if (strcmp("clear", Name) == 0)
    {
        printf("About : Clears the console screen\n");
        printf("Usage : clear\n");
    }
    else
    {
        printf("No manual entry for %s\n", Name);
    }
}

////////////////////////////////////////////////////////////////////////////////////
//
// Function Name      : IsFileExist
//
// Description        : Checks whether a file with the given name already exists in CVFS.
//                      This function traverses the inode linked list and verifies if
//                      a regular file with the specified name is present.
//
// Input              : char *name → Name of the file to check
//
// Output             : Returns true (1) if file exists, false (0) otherwise
//
// Author             : Prathamesh Rajendra Gavandi
//
// Date               : 16/01/2026
//
////////////////////////////////////////////////////////////////////////////////////

bool IsFileExist(
                        char *name      // File name
                )
{
    PINODE temp = head;
    bool bFlag = false;

    while (temp !=  NULL)
    {
        // Checks the file is exists or not
        if((strcmp(name,temp->FileName) == 0) && (temp-> FileType == REGULARFILE))
        { // compare name in Every Inode          // checks the file type REGULARFILE
            bFlag = true;
            break;
        }
        temp = temp -> next;
    }

    return bFlag;
    
}

/////////////////////////////////////////////////////////////////////////////////////////////
//
// Function Name : CreateFile
// Description   : Creates a new regular file in Marvellous CVFS.
//                 This function performs the following steps:
//                 1. Validates file name and permission values.
//                 2. Checks if free inodes are available.
//                 3. Checks if file with the same name already exists.
//                 4. Finds an empty inode and UFDT entry.
//                 5. Allocates memory for FileTable and file data buffer.
//                 6. Initializes inode, file table, and updates SuperBlock.
//
// Input        : char *name → Name of the new file to create
//                int permission → Permission for the file (1: READ, 2: WRITE, 3: READ+WRITE)
//
// Output       : Returns the File Descriptor (FD) on success
//                Returns negative error codes on failure:
//                ERR_INVALID_PARAMETER → Invalid name or permission
//                ERR_NO_INODES → No free inodes available
//                ERR_FILE_ALREADY_EXIST → File with same name exists
//                ERR_MAX_FILES_OPEN → Maximum open files limit reached
//
// Author       : Prathamesh Rajendra Gavandi
// Date         : 16/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////

int CreateFile(
                    char *name,         // Name of new file
                    int permission      // Permission for that file
                )

{
    PINODE temp = head;
    int i = 0;

    printf("Total numbers of Inodes remaining : %d\n",superobj.FreeInodes);

    // If name is missing
    if(name == NULL)
    {
        return ERR_INVALID_PARAMETER;
    }

    // If the permission valye is wrong
    // permission -> 1 -> READ
    // permission -> 2 -> WRITE
    // permission -> 3 -> READ + WRITE

    if(permission < 1 || permission > 3)    // filter for permission is less than 1 and greater than 3
    {
        return ERR_INVALID_PARAMETER;
    }

    // If Inodes are full
    if (superobj.FreeInodes == 0)
    {
        return ERR_NO_INODES;
    }

    // If file is already present
    if(IsFileExist(name) == true)
    {
        return ERR_FILE_ALREADY_EXIST;
    }

    // Search empty Inode
    while (temp != NULL)
    {
        if(temp -> FileType == 0)
        {
            break;
        }

        temp = temp -> next;
    }
    
    if(temp == NULL)
    {
        printf("There is no Inode\n");
        return ERR_NO_INODES;
    }

    // Search for empty UFDT entry
    // NOTE : 0,1,2 are reserved
    for(i = 3; i < MAXOPENFILES; i++)
    {
        if(uareaobj.UFDT[i] == NULL)
        {
            break;
        }
    }

    // UFDT is full
    if(i == MAXOPENFILES)
    {
        return ERR_MAX_FILES_OPEN;
    }

    // Allocate ememory for file table
    uareaobj.UFDT[i] = (PFILETABLE)malloc(sizeof(FILETABLE));

    // Initialise File Table
    uareaobj.UFDT[i]->ReadOffset = 0;
    uareaobj.UFDT[i]->WriteOffset = 0;
    uareaobj.UFDT[i]->Mode = permission;

    // Connect File table with Inode
    uareaobj.UFDT[i]->ptrinode = temp;

    // Initialise elements of Inode
   strcpy(uareaobj.UFDT[i]->ptrinode->FileName,name);
   uareaobj.UFDT[i]->ptrinode->FileSize = MAXFILESIZE;
   uareaobj.UFDT[i]->ptrinode->ActualFileSize = 0;
   uareaobj.UFDT[i]->ptrinode->FileType = REGULARFILE;
   uareaobj.UFDT[i]->ptrinode->ReferenceCount = 1;
   uareaobj.UFDT[i]->ptrinode->Permission = permission;

   // Allocate memory for the files data
   uareaobj.UFDT[i]->ptrinode->Buffer = (char *)malloc(MAXFILESIZE);

   superobj.FreeInodes--;

   return i;        // Returning File Descriptor

}

//////////////////////////////////////////////////////////////////////////////
//
// Function Name      : LsFile
// Description        : Lists all files present in the Marvellous CVFS.
//                      It traverses the inode linked list and prints
//                      details of all regular files.
// Input              : None
// Output             : Displays inode number, file name, and actual file
//                      size of all files
// Author             : Prathamesh Rajendara Gavandi
// Date               : 16/01/2026
//
//////////////////////////////////////////////////////////////////////////////
// ls -l
void LsFile()
{
    PINODE temp = head;

    printf("-----------------------------------------------\n");
    printf("------ Marvellous CVFS Files Information ------\n");
    printf("-----------------------------------------------\n");

    while(temp != NULL)
    {
        if(temp -> FileType != 0)
        {
            printf("%d\t%s\t%d\n",temp->InodeNumber,temp->FileName,temp->ActualFileSize);
        }
        
        temp = temp -> next;
    }
    
    printf("-----------------------------------------------\n");

}

//////////////////////////////////////////////////////////////////////////////
//
// Function Name      : UnlinkFile()
// Description        : It is used to delete the file.
// Input              : File name
// Output             : Nothing
// Author             : Prathamesh Rajendara Gavandi
// Date               : 22/01/2026
//
//////////////////////////////////////////////////////////////////////////////

int UnlinkFile(
                    char *name 
              )
{
    int i = 0;

    if(name == NULL)
    {
        return ERR_INVALID_PARAMETER;
    }

    if(IsFileExist(name) == false)
    {
        return ERR_FILE_NOT_EXIST;
    }

    //check
    // Travel the UFDT
    for(i = 0; i< MAXOPENFILES; i++)
    {
        if(uareaobj.UFDT[i] != NULL)
        {
            if(strcmp(uareaobj.UFDT[i]->ptrinode->FileName, name) == 0)//finds the file you wanted to delete
            {
                // Deallocate memory of Buffer
                free(uareaobj.UFDT[i]->ptrinode->Buffer);
                uareaobj.UFDT[i]->ptrinode->Buffer = NULL;

                // Reset all values of inode
                // Dont deallocate memory of inode
                uareaobj.UFDT[i]->ptrinode->FileSize = 0;
                uareaobj.UFDT[i]->ptrinode->ActualFileSize = 0;
                uareaobj.UFDT[i]->ptrinode->FileType = 0;
                uareaobj.UFDT[i]->ptrinode->ReferenceCount = 0;
                uareaobj.UFDT[i]->ptrinode->Permission = 0;

                // clear the file name reset to '\0'
                memset(uareaobj.UFDT[i]->ptrinode->FileName, '\0',sizeof(uareaobj.UFDT[i]->ptrinode->FileName));

                // Deallocate the memory of file table
                free(uareaobj.UFDT[i]);

                // Set NULL to UFDT
                uareaobj.UFDT[i] = NULL;

                // Increment free Inodes count
                superobj.FreeInodes++;

                break;  // IMP breaks the for loop when find the name

            }  // End of if
        }      // End of if
    }          // End of for 

    return EXECUTE_SUCCESS;

}              // End of function

//check
//////////////////////////////////////////////////////////////////////////////
//
// Function Name      : WriteFile()
// Description        : It is used to write the data into the file.
// Input              : File descriptor
//                      Address of Buffer which contains data
//                      Size of data that we want to write
// Output             : Number of Bytes successfully written
// Author             : Prathamesh Rajendara Gavandi
// Date               : 22/01/2026
//
//////////////////////////////////////////////////////////////////////////////

int WriteFile(
                int fd,
                char *data,
                int size
             )
{
    printf("File descriptor : %d\n",fd);
    printf("Data that we want to write : %s\n",data);
    printf("Number of bytes that we want to write : %d\n",size);

    // Invalid FD
    if (fd < 0 || fd > MAXOPENFILES)
    {
        return ERR_INVALID_PARAMETER;
    }

    // FD points to NULL
    if(uareaobj.UFDT[fd] == NULL)
    {
        return ERR_FILE_NOT_EXIST;
    }

    // There is no permission to write
    if(uareaobj.UFDT[fd]->ptrinode->Permission < WRITE)
    {
        return ERR_PERMISSION_DENIED;
    }

    // Insufficient space
    if((MAXFILESIZE - uareaobj.UFDT[fd]->WriteOffset) < size)
    {
        return ERR_INSUFFICIENT_SPACE;
    }


    // Write the data into the file
    strncpy(uareaobj.UFDT[fd]->ptrinode->Buffer + uareaobj.UFDT[fd]->WriteOffset, data, size);  // copy the data that we told
    
    // Update the write offset
    uareaobj.UFDT[fd]->WriteOffset = uareaobj.UFDT[fd]->WriteOffset + size;

    // Update the actual file size
    uareaobj.UFDT[fd]->ptrinode->ActualFileSize = uareaobj.UFDT[fd]->ptrinode->ActualFileSize + size;

    return size;
}


//////////////////////////////////////////////////////////////////////////////
//
// Function Name      : ReadFile()
// Description        : It is used to read the data from the file.
// Input              : File descriptor
//                      Address of empty Buffer
//                      Size of data that we want to read
// Output             : Number of Bytes successfully read
// Author             : Prathamesh Rajendara Gavandi
// Date               : 22/01/2026
//
//////////////////////////////////////////////////////////////////////////////

int ReadFile(
                int fd,
                char *data,
                int size
            )
{

    // Invalid Fd
    if(fd < 0 || fd > MAXOPENFILES)
    {
        return ERR_INVALID_PARAMETER;
    }

    if(data == NULL)
    {
        return ERR_INVALID_PARAMETER;
    }

    if(size <= 0)
    {
        return ERR_INVALID_PARAMETER;
    }

    if(uareaobj.UFDT[fd] == NULL)
    {
        return ERR_FILE_NOT_EXIST;
    }

    // Filter for permission
    if(uareaobj.UFDT[fd]->ptrinode->Permission < READ)
    {
        return ERR_PERMISSION_DENIED;
    }

    // Insufficient data
    if((MAXFILESIZE - uareaobj.UFDT[fd]->ReadOffset) < size)
    {
        return ERR_INSUFFICIENT_DATA;
    }

    // Read the data
    strncpy(data,uareaobj.UFDT[fd]->ptrinode->Buffer + uareaobj.UFDT[fd]->ReadOffset, size);

    // Update the read offset
    uareaobj.UFDT[fd]->ReadOffset = uareaobj.UFDT[fd]->ReadOffset + size;

    return size;
    
}

////////////////////////////////////////////////////////////////////////////////
//
//  Entry Point Function Of The Project
//
////////////////////////////////////////////////////////////////////////////////

int main()
{
    char str[80] = {'\0'};
    char Command[5][20] = {{'\0'}};
    char InputBuffer[MAXFILESIZE] = {'\0'};

    char *EmptyBuffer = NULL;

    int iCount = 0;
    int iRet = 0;

    StartAuxillaryDataInitilisation();

    printf("-----------------------------------------------\n");
    printf("----- Marvellous CVFS started succesfully -----\n");
    printf("-----------------------------------------------\n");
    
    // Infinite Listening Shell
    while(1)
    {
        fflush(stdin);

        strcpy(str,"");

        printf("\nMarvellous CVFS : > ");
        fgets(str,sizeof(str),stdin);
        
        iCount = sscanf(str,"%s %s %s %s %s",Command[0],Command[1],Command[2],Command[3], Command[4]);

        fflush(stdin);

        if(iCount == 1)
        {
            // Marvellous CVFS : > exit
            if(strcmp("exit",Command[0]) == 0)
            {
                printf("Thank you for using Marvellous CVFS\n");
                printf("Deallocating all the allocated resources\n");

                break;
            }
            // Marvellous CVFS : > ls
            else if(strcmp("ls",Command[0]) == 0)
            {
                LsFile();
            }
            // Marvellous CVFS : > help
            else if(strcmp("help",Command[0]) == 0)
            {
                DisplayHelp();
            }
            // Marvellous CVFS : > clear
            else if(strcmp("clear",Command[0]) == 0)
            {
                #ifdef _WIN32
                    system("cls");
                #else
                    system("clear");
                #endif
            }
        } // End of else if 1
        else if(iCount == 2)
        {
            // Marvellous CVFS : > man ls
            if(strcmp("man",Command[0]) == 0)
            {
                ManPageDisplay(Command[1]);
            }
            // Marvellous CVFS : > unlink Demo.txt
            if(strcmp("unlink",Command[0]) == 0)
            {
                iRet = UnlinkFile(Command[1]);
            
                if(iRet == ERR_INVALID_PARAMETER)
                {
                    printf("Error : Invalid parameter\n");
                }

                if(iRet == ERR_FILE_NOT_EXIST)
                {
                    printf("Error : Unable to delete as there is no such file");
                }

                if(iRet == EXECUTE_SUCCESS)
                {
                    printf("File gets succesfully deleted\n");
                }
            }
            // Marvellous CVFS : > write 2
            else if(strcmp("write",Command[0]) == 0)
            {
                printf("Enter the data that you want to write : \n");
                fgets(InputBuffer,MAXFILESIZE,stdin);

                iRet = WriteFile(atoi(Command[1]), InputBuffer, strlen(InputBuffer)-1);
            
                if(iRet == ERR_INVALID_PARAMETER)
                {
                    printf("Error : Invalid parameters \n");
                }
                else if(iRet == ERR_FILE_NOT_EXIST)
                {
                    printf("Error : There is no such file\n");
                }
                else if(iRet == ERR_PERMISSION_DENIED)
                {
                    printf("Error : Unable to write as there is no permission\n");
                }
                else if(iRet == ERR_INSUFFICIENT_SPACE)
                {
                    printf("Error : Unable to write as there is no space\n");
                }
                else
                {
                    printf("%d bytes gets succesfully written\n",iRet);
                }
            }
            else
            {
                printf("There is no such command\n");
            }
        } // End of else if 2
        else if(iCount == 3)
        {
            // Marvellous CVFS : > creat Ganesh.txt 3
            if(strcmp("creat",Command[0]) == 0)
            {
                iRet = CreateFile(Command[1],atoi(Command[2]));

                if(iRet == ERR_INVALID_PARAMETER)
                {
                    printf("Error : Unable to create the file as parameters are invalid\n");
                    printf("Please refer man page\n");
                }

                if(iRet == ERR_NO_INODES)
                {
                    printf("Error : Unable to create file as there is no inode\n");
                }

                if(iRet == ERR_FILE_ALREADY_EXIST)
                {
                    printf("Error : Unable to create file because the file is already present\n");
                }

                if(iRet == ERR_MAX_FILES_OPEN)
                {
                    printf("Error : Unable to create file\n");
                    printf("Max opened files limit reached\n");
                }

                printf("File gets succesfully created with FD %d\n",iRet);
            } 
            // Marvellous CVFS : > read 3 10
            if(strcmp("read",Command[0]) == 0)
            {
                EmptyBuffer = (char *)malloc(sizeof(atoi(Command[2])));

                iRet = ReadFile(atoi(Command[1]), EmptyBuffer, atoi(Command[2]));

                if(iRet == ERR_INVALID_PARAMETER)
                {
                    printf("Error : Invalid parameter\n");
                }
                else if(iRet == ERR_FILE_NOT_EXIST)
                {
                    printf("Error : File not exist\n");
                }
                else if(iRet == ERR_PERMISSION_DENIED)
                {
                    printf("Error : Permission denied\n");
                }
                else if(iRet == ERR_INSUFFICIENT_DATA)
                {
                    printf("Error : Insufficient data\n");
                }
                else
                {
                    printf("Read operation is succesful\n");
                    printf("Data from file is : %s\n",EmptyBuffer);

                    free(EmptyBuffer);
                }
            }
            else
            {
                printf("There is no such command\n");
            }
        } // End of else if 3
        else if(iCount == 4)
        {

        } // End of else if 4
        else
        {
            printf("Command not found\n");
            printf("Please refer help option to get more information\n");
        } // End of else
    } // End of while

    return 0;
} // End of main
