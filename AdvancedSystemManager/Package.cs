using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedSystemManager
{
    class Package
    {
        public String PackageName { set; get; }
        //String DisplayVersion { set; get; }
        public String Publisher { set; get; }
        public String UninstallString { set; get; }
        public String QuietUninstallString { set; get; }
        public UInt32 EstimatedSizeInKB { set; get; }
        public Boolean IsSystemComponent { set; get; }
        public Boolean isSafeToRemove { set; get; }
        //public Boolean isInnoSetup { set; get; }
        public Boolean ToRemove { set; get; }

       // Package pack = new Package(productName, publisher, estSize, unString, quietUnString);
        public Package(String packName,String pub,Boolean sysComp, UInt32 size,String uniString,String quietUniString)
        {
            this.PackageName = packName;
            //this.DisplayVersion = dispVer;
            this.Publisher = pub;
            this.EstimatedSizeInKB = size;
            this.UninstallString = uniString;
            this.QuietUninstallString = quietUniString;
            this.IsSystemComponent = sysComp;

            this.isSafeToRemove = false;
           // this.isInnoSetup = false;
            this.ToRemove = false;
        }
    }

    class PackageComparer : IComparer<Package>
    {
        public int Compare(Package x, Package y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.PackageName.CompareTo(y.PackageName);

                    if (retval != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return retval;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        return x.PackageName.CompareTo(y.PackageName);
                    }
                }
            }
        }
    }

}
