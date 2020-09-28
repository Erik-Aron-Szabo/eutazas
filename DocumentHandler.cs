using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace eutazas
{
    public class DocumentHandler
    {
        // This class will be used for parsing the document 'utasadat.txt'

        private static DocumentHandler singleton;
        private DocumentHandler()
        {

        }

        public static DocumentHandler GetDocumentHandler()
        {
            if (singleton == null)
            {
                singleton = new DocumentHandler();
            }
            return singleton;
        }


        // change void to return Array
        public string[] Reader(string filePath)
        {

            string[] lines = File.ReadAllLines(filePath);


            return lines;
        }

        public void Writer(string[] lines, string filepath)
        {

            File.AppendAllLines(filepath, lines);

        }

    }
}
