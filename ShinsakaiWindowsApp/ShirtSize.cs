using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinsakaiWindowsApp
{
    public enum ShirtSize
    {
        None,
        Child_Small,
        Child_Medium,
        Child_Large,
        Adult_Small,
        Adult_Medium,
        Adult_Large,
        Adult_XLarge
    }


    public static class ShirtSizeTextProvider
    {
        public static string getDesc(this ShirtSize t)
        {
            switch (t)
            {
                case ShirtSize.Child_Small:
                    return "Child Small";
                case ShirtSize.Child_Medium:
                    return "Child Medium";
                case ShirtSize.Child_Large:
                    return "Child Large";
                case ShirtSize.Adult_Small:
                    return "Adult Small";
                case ShirtSize.Adult_Medium:
                    return "Adult Medium";
                case ShirtSize.Adult_Large:
                    return "Adult Large";
                case ShirtSize.Adult_XLarge:
                    return "Adult XLarge";
                case ShirtSize.None:
                default:
                    return "None";
            }
        }
    }
            }
