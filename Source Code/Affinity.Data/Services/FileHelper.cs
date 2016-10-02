using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Affinity.Helper.Services
{
    /// <summary>
    /// Save the file temporary and 
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// The FileName full path.
        /// </summary>
        private string _fileName { get; set; }

        /// <summary>
        /// The _byte of File.
        /// </summary>
        private Byte[] _byte { get; set; }

        /// <summary>
        /// Initialize with File name
        /// </summary>
        /// <param name="myFileName">The File Name,</param>
        public  FileHelper(string myFileName)
        {
            _fileName = myFileName;
        }

        /// <summary>
        /// Initialize and create the temp file based on Stream
        /// </summary>
        /// <param name="myFileName">The File Name , Full Path</param>
        /// <param name="mem">Memory Stream</param>
        public FileHelper(string myFileName,Byte[] mem)
        {
            System.IO.FileStream _f = new System.IO.FileStream(myFileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            _f.Write(mem, 0, mem.Length);
              _f.Close();
            _fileName = myFileName;
            _byte = mem;
        }

        /// <summary>
        /// This initilization use only the byte array.
        /// </summary>
        /// <param name="mem">byte array</param>
        public FileHelper(Byte[] mem)
        {
            _fileName = "";
            _byte = mem;
        }


        /// <summary>
        /// Get File Entries Based on Memory Stream 
        /// </summary>
        /// <returns>A List of Records as String array</returns>
        public List<string[]> GetFileEntries(Boolean noSkip=false)
        {
            string line = "";
            var myValues = new List<string[]>();

            MemoryStream mem = new MemoryStream(_byte);
            var i = 0;
            using (StreamReader file = new StreamReader(mem))
            {
                
                while ((line = file.ReadLine()) != null)
                {
                   
                    char[] delimeter = new char[] { '\t' };
                    string[] fields = line.Split(delimeter, StringSplitOptions.RemoveEmptyEntries);
                    if (i!=0)
                    {
                        myValues.Add(fields);
                    }
                    else
                    {
                        if (noSkip==true)
                        {
                            myValues.Add(fields);
                        }
                    }
                 
                    i = i + 1;

                }
            }


            return myValues;
        }


        /// <summary>
        /// Get File Entries
        /// </summary>
        /// <returns>Convert File to Records.</returns>
        public List<string[]> GetFileContent()
        {
            string line = "";
            var myValues = new List<string[]>();
            using (StreamReader file = new StreamReader(_fileName))
            {
                while ((line=file.ReadLine())!=null)
                {
                    char[] delimeter = new char[] { '\t' };
                    string[] fields = line.Split(delimeter, StringSplitOptions.RemoveEmptyEntries);
                    myValues.Add(fields);
                }
            }

              
            return myValues;
        }

        /// <summary>
        /// Delete the temporary file.
        /// </summary>
        public void DeleteFile()
        {
            if (System.IO.File.Exists(_fileName))
            {
                System.IO.File.Delete(_fileName);
            }
           
        }
    }
}
