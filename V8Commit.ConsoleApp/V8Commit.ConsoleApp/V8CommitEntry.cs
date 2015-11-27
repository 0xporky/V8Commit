﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using V8Commit.Repositories;
using V8Commit.Services;
using V8Commit.Services.HashServices;

namespace V8Commit.ConsoleApp
{
    class V8CommitEntry
    {
        static void Main(string[] args)
        {
            IV8CommitRepository testContainer = new FileV8CommitRepository(@"D:\V8Commit\V8Commit.TestData\Обработка1.epf");
            var fileSystem = testContainer.ReadV8FileSystem();

            Console.WriteLine("Container:");
            Console.WriteLine(fileSystem.Container.RefToNextPage);
            Console.WriteLine(fileSystem.Container.PageSize);
            Console.WriteLine(fileSystem.Container.PagesCount);
            Console.WriteLine(fileSystem.Container.ReservedField);

            Console.WriteLine("\nBlock header:");
            Console.WriteLine(fileSystem.BlockHeader.DataSize);
            Console.WriteLine(fileSystem.BlockHeader.PageSize);
            Console.WriteLine(fileSystem.BlockHeader.RefToNextPage);

            DateTime start = new DateTime(1, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            foreach (var c in fileSystem.References)
            {
                Console.WriteLine("\nSystem reference:");
                Console.WriteLine(start.AddMilliseconds(c.FileHeader.CreationDate / 1000 * 100).ToLocalTime());
                Console.WriteLine(start.AddMilliseconds(c.FileHeader.ModificationDate / 1000 * 100).ToLocalTime());
                Console.WriteLine(c.FileHeader.ReservedField);
                Console.WriteLine(c.FileHeader.FileName);
            }

        }
    }
}
