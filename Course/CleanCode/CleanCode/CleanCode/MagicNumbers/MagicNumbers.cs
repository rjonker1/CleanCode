
namespace CleanCode.MagicNumbers
{
    public class MagicNumbers
    {
        public void ApproveDocument(DocumentStatus status)
        {
            if (status == DocumentStatus.Draft)
            {
                // ...
            }
            else if (status == DocumentStatus.Lodged)
            {
                // ...
            }
        }

        public void RejectDocument(DocumentStatus status)
        {
            switch (status)
            {
                case DocumentStatus.Draft:
                    // ...
                    break;
                case DocumentStatus.Lodged:
                    // ...
                    break;
            }
        }

        //SMELLY -magic numbers
        //public void ApproveDocument(int status)
        //{
        //    if (status == 1)
        //    {
        //        // ...
        //    }
        //    else if (status == 2)
        //    {
        //        // ...
        //    }
        //}

        //SMELLY - magic string
        //public void RejectDoument(string status)
        //{
        //    switch (status)
        //    {
        //        case "1":
        //            // ...
        //            break;
        //        case "2":
        //            // ...
        //            break;
        //    }
        //}
    }
}
