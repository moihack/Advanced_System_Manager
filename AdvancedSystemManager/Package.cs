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
        public String EstimatedSizeInKB { set; get; }
        public Boolean IsSystemComponent { set; get; }
        public Boolean isSafeToRemove { set; get; }
        //public Boolean isInnoSetup { set; get; }
        public Boolean ToRemove { set; get; }

       // Package pack = new Package(productName, publisher, estSize, unString, quietUnString);
        public Package(String packName,String pub,Boolean sysComp, decimal size,String uniString,String quietUniString)
        {
            this.PackageName = packName;
            //this.DisplayVersion = dispVer;
            this.Publisher = pub;

            /* if (size / 1024 > 1000) //GB
             {
                 //  this.EstimatedSizeInKB = size / 1024 / 1024;
                 //  Math.Round(this.EstimatedSizeInKB,2);
                 decimal tempsize = size / 1024 / 1024;
                 tempsize = Math.Round(tempsize, 2);
                 this.EstimatedSizeInKB = tempsize.ToString() + " GB";
             }

             if (size/1024/1024 < 1000) //MB
             {
                 //  this.EstimatedSizeInKB = size / 1024;
                 // Math.Round(this.EstimatedSizeInKB,2);
                 decimal tempsize = size/1024;
                 tempsize = Math.Round(tempsize, 2);
                 this.EstimatedSizeInKB = tempsize.ToString() + " MB";
             }

             if (size / 1024 < 1000 && size > 0) //KB
             {
                 // this.EstimatedSizeInKB = size;
                 //Math.Round(this.EstimatedSizeInKB,2);
                 decimal tempsize = size;
                 tempsize = Math.Round(tempsize, 2);
                 this.EstimatedSizeInKB = tempsize.ToString() + " KB";
             } */

            //size2 = size2 / 1024;

            if(size < 1000)
            {
                decimal tempsize = size;
                tempsize = Math.Round(tempsize, 2);
                this.EstimatedSizeInKB = tempsize.ToString() + " KB";
            }
            
            if (size>1000)
            {
                size = size / 1024;
                decimal tempsize = size;
                tempsize = Math.Round(tempsize, 2);
                this.EstimatedSizeInKB = tempsize.ToString() + " MB";
            }

            if ( size > 1000)
            {
                size = size / 1024;
                decimal tempsize = size;
                tempsize = Math.Round(tempsize, 2);
                this.EstimatedSizeInKB = tempsize.ToString() + " GB";
            }

            //must remain last - otherwise 0MB appears
            if (size == 0)
            {
                this.EstimatedSizeInKB = "";
            }

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
