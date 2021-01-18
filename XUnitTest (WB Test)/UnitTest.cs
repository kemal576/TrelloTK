using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace XUnitTest__WB_Test_
{
    public class UnitTest
    {
        [Fact]
        public void IdKontrol_TEST()
        {
            txtWrite();
            List<int> sorunlar = new List<int>();
            for (int i = 1000; i < 9999; i++)
            {
                if (TrelloTK.DataManager.IdKontrol_txt(i.ToString()))
                {
                    sorunlar.Add(i);
                }
            }
            Assert.Equal(0.ToString(), sorunlar.Count.ToString());
        }

        public static void txtWrite()
        {
            string a = "&";
            string filePath = "todo.txt";
            FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 1000; i < 9999; i++)
            {
                sw.WriteLine(i + a + "title");
            }
            sw.Close();
        }
    }
}
