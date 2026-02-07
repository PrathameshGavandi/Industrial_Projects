/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  File Name   :     PackerGUI.java
//  Project     :     Customized File Packer-Unpacker
//  Description :     GUI based application to pack all .txt files from a folder
//                    into a single file using fixed-size header and XOR encryption.
//  Input       :     Folder selected using GUI
//                    Name of packed output file
//  Output      :     Single packed file
//  Author      :     Prathamesh Rajendra Gavandi
//  Date        :     27/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

import java.io.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

class PackerGUI extends JFrame implements ActionListener
{
    // GUI Components
    JButton browseBtn, packBtn;
    JTextField folderField, packField;
    JTextArea logArea;
    JFileChooser chooser;

    // Encryption key
    byte Key = 0x11;

    PackerGUI()
    {
        setTitle("Customized File Packer");
        setSize(650,450);
        setLayout(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JLabel lbl1 = new JLabel("Select Folder:");
        lbl1.setBounds(30,30,150,30);
        add(lbl1);

        folderField = new JTextField();
        folderField.setBounds(180,30,300,30);
        add(folderField);

        browseBtn = new JButton("Browse");
        browseBtn.setBounds(500,30,100,30);
        browseBtn.addActionListener(this);
        add(browseBtn);

        JLabel lbl2 = new JLabel("Packed File Name:");
        lbl2.setBounds(30,80,150,30);
        add(lbl2);

        packField = new JTextField();
        packField.setBounds(180,80,300,30);
        add(packField);

        packBtn = new JButton("Pack");
        packBtn.setBounds(260,130,120,35);
        packBtn.addActionListener(this);
        add(packBtn);

        logArea = new JTextArea();
        logArea.setEditable(false);

        JScrollPane sp = new JScrollPane(logArea);
        sp.setBounds(30,190,570,200);
        add(sp);

        setVisible(true);
    }

    public void actionPerformed(ActionEvent ae)
    {
        if(ae.getSource() == browseBtn)
        {
            chooser = new JFileChooser();
            chooser.setFileSelectionMode(JFileChooser.DIRECTORIES_ONLY);

            int ret = chooser.showOpenDialog(this);
            if(ret == JFileChooser.APPROVE_OPTION)
            {
                folderField.setText(chooser.getSelectedFile().getAbsolutePath());
            }
        }
        else if(ae.getSource() == packBtn)
        {
            PackFiles();
        }
    }

    void PackFiles()
    {
        // Variable declarations
        String Header = null;
        int iRet = 0;
        int i = 0, j = 0;

        byte Buffer[] = new byte[1024];
        byte bHeader[] = new byte[100];

        File fobj = null;
        File PackObj = null;
        FileInputStream fiobj = null;
        FileOutputStream foobj = null;

        try
        {
            String FolderName = folderField.getText();
            String PackName = packField.getText();

            if(FolderName.length() == 0 || PackName.length() == 0)
            {
                logArea.append("Please select folder and enter packed file name\n");
                return;
            }

            fobj = new File(FolderName);

            if((fobj.exists() == false) || (fobj.isDirectory() == false))
            {
                logArea.append("Invalid folder\n");
                return;
            }

            PackObj = new File(PackName);
            PackObj.createNewFile();

            foobj = new FileOutputStream(PackObj);

            File fArr[] = fobj.listFiles();

            logArea.append("Packing started...\n");

            for(i = 0; i < fArr.length; i++)
            {
                if(fArr[i].isFile() && fArr[i].getName().endsWith(".txt"))
                {
                    logArea.append("Packing : " + fArr[i].getName() + "\n");

                    fiobj = new FileInputStream(fArr[i]);

                    // Header creation
                    Header = fArr[i].getName() + " " + fArr[i].length();

                    for(j = Header.length(); j < 100; j++)
                    {
                        Header = Header + " ";
                    }

                    bHeader = Header.getBytes();
                    foobj.write(bHeader,0,100);

                    while((iRet = fiobj.read(Buffer)) != -1)
                    {
                        // Encryption
                        for(j = 0; j < iRet; j++)
                        {
                            Buffer[j] = (byte)(Buffer[j] ^ Key);
                        }

                        foobj.write(Buffer,0,iRet);
                    }

                    fiobj.close();
                }
            }

            foobj.close();
            logArea.append("Packing completed successfully\n");
        }
        catch(Exception e)
        {
            logArea.append("Error : " + e.getMessage() + "\n");
        }
    }

    public static void main(String A[])
    {
        new PackerGUI();
    }
}
