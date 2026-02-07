/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  File Name   :     Unpacker.java
//  Project     :     Customized File Packer-Unpacker
//  Description :     Extracts all packed .txt files from a single packed file
//                    by reading fixed-size headers and applying XOR decryption.
//  Input       :     Name of packed input file
//  Output      :     Original .txt files extracted from packed file
//  Author      :     Prathamesh Rajendra Gavandi
//  Date        :     27/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////


import java.io.*;
import java.util.*;

class Unpacker
{
    public static void main(String A[]) throws Exception
    {
        // Variables for file size and counters
        int FileSize = 0;
        int i = 0;
        int iRet = 0;

        // Same encryption key used during packing
        byte Key = 0x11;

        // Objects declared as null (clean coding practice)
        Scanner sobj = null;
        String FileName = null;
        String Header = null;
        String Tokens[] = null;

        File fpackobj = null;   // Packed file object
        File fobj = null;       // Extracted file object

        FileInputStream fiobj = null;   // For reading packed file
        FileOutputStream foobj = null;  // For writing extracted file

        // Header buffer (100 bytes)
        byte bHeader[] = new byte[100];

        // Data buffer
        byte Buffer[] = null;

        // Take packed file name from user
        sobj = new Scanner(System.in);
        System.out.println("Enter the name of packed file : ");
        FileName = sobj.nextLine();

        fpackobj = new File(FileName);

        // Check if packed file exists
        if(fpackobj.exists() == false)
        {
            System.out.println("Error : There is no such packed file");
            return;
        }

        // Open packed file
        fiobj = new FileInputStream(fpackobj);

        // Read header continuously till end of file
        while((iRet = fiobj.read(bHeader,0,100)) != -1)
        {
            // Convert header bytes to string
            Header = new String(bHeader);

            // Remove extra spaces
            Header = Header.trim();

            // Split header into file name and size
            Tokens = Header.split(" ");

            System.out.println("File name : " + Tokens[0]);
            System.out.println("File size : " + Tokens[1]);

            // Create new extracted file
            fobj = new File(Tokens[0]);
            fobj.createNewFile();

            foobj = new FileOutputStream(fobj);

            // Convert file size from string to integer
            FileSize = Integer.parseInt(Tokens[1]);

            // Allocate buffer according to file size
            Buffer = new byte[FileSize];

            // Read encrypted data
            fiobj.read(Buffer,0,FileSize);

            // Decrypt data using XOR
            for(i = 0; i < FileSize ; i++)
            {
                Buffer[i] = (byte)(Buffer[i] ^ Key);
            }

            // Write decrypted data into file
            foobj.write(Buffer,0,FileSize);

            // Close output file
            foobj.close();
        }

        // Close resources
        fiobj.close();
        sobj.close();

        System.out.println("Unpacking completed successfully");
    }
}
