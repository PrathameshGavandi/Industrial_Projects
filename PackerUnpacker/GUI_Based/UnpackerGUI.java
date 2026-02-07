/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//  File Name   :     UnpackerGUI.java
//  Project     :     Customized File Packer-Unpacker
//  Description :     GUI based application to unpack files from a packed file
//                    using fixed-size headers and XOR decryption technique.
//  Input       :     Packed file selected using GUI
//  Output      :     Original .txt files extracted from packed file
//  Author      :     Prathamesh Rajendra Gavandi
//  Date        :     27/01/2026
//
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

import java.io.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

class UnpackerGUI extends JFrame implements ActionListener
{
    // GUI Components
    JButton browseBtn, unpackBtn;
    JTextField fileField;
    JTextArea logArea;
    JFileChooser chooser;

    // Encryption key
    byte Key = 0x11;

    UnpackerGUI()
    {
        setTitle("Customized File Unpacker");
        setSize(600,400);
        setLayout(null);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);

        JLabel lbl = new JLabel("Select Packed File:");
        lbl.setBounds(30,30,150,30);
        add(lbl);

        fileField = new JTextField();
        fileField.setBounds(180,30,280,30);
        add(fileField);

        browseBtn = new JButton("Browse");
        browseBtn.setBounds(470,30,90,30);
        browseBtn.addActionListener(this);
        add(browseBtn);

        unpackBtn = new JButton("Unpack");
        unpackBtn.setBounds(230,80,120,30);
        unpackBtn.addActionListener(this);
        add(unpackBtn);

        logArea = new JTextArea();
        logArea.setEditable(false);

        JScrollPane sp = new JScrollPane(logArea);
        sp.setBounds(30,130,530,200);
        add(sp);

        setVisible(true);
    }

    public void actionPerformed(ActionEvent ae)
    {
        if(ae.getSource() == browseBtn)
        {
            chooser = new JFileChooser();
            int ret = chooser.showOpenDialog(this);

            if(ret == JFileChooser.APPROVE_OPTION)
            {
                fileField.setText(chooser.getSelectedFile().getAbsolutePath());
            }
        }
        else if(ae.getSource() == unpackBtn)
        {
            UnpackFile();
        }
    }

    void UnpackFile()
    {
        // Variable declaration
        int FileSize = 0;
        int i = 0;
        int iRet = 0;

        String FileName = null;
        String Header = null;
        String Tokens[] = null;

        File fpackobj = null;
        File fobj = null;

        FileInputStream fiobj = null;
        FileOutputStream foobj = null;

        byte bHeader[] = new byte[100];
        byte Buffer[] = null;

        try
        {
            FileName = fileField.getText();

            if(FileName.length() == 0)
            {
                logArea.append("Please select packed file\n");
                return;
            }

            fpackobj = new File(FileName);

            if(fpackobj.exists() == false)
            {
                logArea.append("Packed file does not exist\n");
                return;
            }

            fiobj = new FileInputStream(fpackobj);

            while((iRet = fiobj.read(bHeader,0,100)) != -1)
            {
                Header = new String(bHeader);
                Header = Header.trim();

                Tokens = Header.split(" ");

                logArea.append("Extracting : " + Tokens[0] + "\n");

                fobj = new File(Tokens[0]);
                fobj.createNewFile();

                foobj = new FileOutputStream(fobj);

                FileSize = Integer.parseInt(Tokens[1]);
                Buffer = new byte[FileSize];

                fiobj.read(Buffer,0,FileSize);

                // Decryption
                for(i = 0; i < FileSize; i++)
                {
                    Buffer[i] = (byte)(Buffer[i] ^ Key);
                }

                foobj.write(Buffer,0,FileSize);
                foobj.close();
            }

            fiobj.close();
            logArea.append("Unpacking completed successfully\n");
        }
        catch(Exception e)
        {
            logArea.append("Error : " + e.getMessage() + "\n");
        }
    }

    public static void main(String A[])
    {
        new UnpackerGUI();
    }
}
