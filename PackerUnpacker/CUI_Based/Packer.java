/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  File Name   :     Packer.java
//  Project     :     Customized File Packer-Unpacker
//  Description :     Packs all .txt files from a given folder into a single file
//                    using fixed-size header and XOR encryption technique.
//  Input       :     Folder name containing .txt files
//                    Name of packed output file
//  Output      :     Single packed file containing encrypted data of all text files
//  Author      :     Prathamesh Rajendra Gavandi
//  Date        :     22/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

import java.io.*;
import java.util.*;

class Packer
{
    public static void main(String A[]) throws Exception
    {
        // Header will store file name and file size
        String Header = null;

        // Encryption key (same key used for unpacking)
        byte Key = 0x11;

        int iRet = 0;      // Stores number of bytes read
        int i = 0, j = 0;

        // Buffer for reading file data
        byte Buffer[] = new byte[1024];

        // Fixed size header of 100 bytes
        byte bHeader[] = new byte[100];

        // Scanner object for user input
        Scanner sobj = new Scanner(System.in);

        System.out.println("Enter the name of folder : ");
        String FolderName = sobj.nextLine();

        System.out.println("Enter the name of packed file : ");
        String PackName = sobj.nextLine();

        // File object for folder
        File fobj = new File(FolderName);

        // Check whether folder exists and is directory
        if((fobj.exists()) && (fobj.isDirectory()))
        {
            // Create packed file
            File PackObj = new File(PackName);
            PackObj.createNewFile();

            // Output stream to write packed data
            FileOutputStream foobj = new FileOutputStream(PackObj);

            // Input stream declared as null (best practice)
            FileInputStream fiobj = null;

            System.out.println("Folder is present");

            // Get list of all files from folder
            File fArr[] = fobj.listFiles();

            System.out.println("Number of files in the folder are : "+fArr.length);

            // Traverse through all files
            for(i = 0; i < fArr.length; i++)
            {
                // Process only .txt files
                if(fArr[i].isFile() && fArr[i].getName().endsWith(".txt"))
                {
                    // Open file
                    fiobj = new FileInputStream(fArr[i]);

                    // Header formation : FileName FileSize
                    Header = fArr[i].getName() + " " + fArr[i].length();

                    // Pad header to 100 bytes
                    for(j = Header.length(); j < 100; j++)
                    {
                        Header = Header + " ";
                    }

                    // Convert header to byte array
                    bHeader = Header.getBytes();

                    // Write header into packed file
                    foobj.write(bHeader,0,100);

                    // Read file data and encrypt it
                    while((iRet = fiobj.read(Buffer)) != -1)
                    {
                        // Encryption logic using XOR
                        for(j = 0; j < iRet; j++)
                        {
                            Buffer[j] = (byte)(Buffer[j] ^ Key);
                        }

                        // Write encrypted data into packed file
                        foobj.write(Buffer,0,iRet);
                    }

                    // Close input file
                    fiobj.close();
                }
            }

            // Close packed file
            foobj.close();
            sobj.close();

            System.out.println("Packing completed successfully");
        }
        else
        {
            System.out.println("There is no such folder");
        }
    }
}
