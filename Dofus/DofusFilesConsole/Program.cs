using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dofus.IO;
using Dofus.Files.Utils;
using System.Diagnostics;

namespace DofusFilesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();

            DofusConfig.Instance.AppDirectory = @"D:\Program Files (x86)\Ankama\Dofus\app";
            long tot = 0, nb = 20;
            for (int i = 0; i < nb; i++)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                DofusConfig.Instance.GetDofusVersion();
                var i18n = DofusFilesUtils.CreateI18nFileReader();

                i18n.Load(DofusConfig.Instance.GetI18NFilePath(Language.French));
                var file = DofusFilesUtils.CreatePakedFile();
                file.Load(@"D:\Fichiers_d2p_2.6.2\maps\maps0.d2p");
                stopwatch.Stop();
                Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms");
                tot += stopwatch.ElapsedMilliseconds;
            }
            Console.WriteLine($"Avg: {tot / nb}ms");
            Console.ReadLine();
        }
    }
}
