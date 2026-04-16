using System;
using System.Collections.Generic;
using System.Text;

[assembly: CLSCompliant(true)]  

namespace Lap6AdvancedC_
{
    [CLSCompliant(true)]
    public class AttributeDemo
    {
        [Obsolete("Use NewMethod instead", false)]
        public void OldMethod()
        {
            Console.WriteLine("Old Method");
        }

        [Obsolete("This method is deprecated", true)]
        public void VeryOldMethod()
        {
            Console.WriteLine("Very Old Method");
        }

        public void NewMethod()
        {
            Console.WriteLine("New Method");
        }
    }


    // Flags Attribute Example
    enum TextStyling2
    {
        Bold = 1,
        Italic = 2,
        Underline = 4
    }

    [Flags]
    enum TextStyling
    {
        Bold = 1,
        Italic = 2,
        Underline = 4
    }
}