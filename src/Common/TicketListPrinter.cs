using System;
using System.Collections.Generic;

using Common.Entities;

namespace Common
{

    public static class TicketListPrinter
    {
        public static void PrintPretty(this List<Ticket> list)
        {
            if (list == null || list.Count == 0)
                return;

            foreach(var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }

}