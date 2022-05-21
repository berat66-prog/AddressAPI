namespace AddressAPI.Exception
{

    [Serializable]
    public class RecordNotFoundException : IOException
    {

        public RecordNotFoundException()
        {

        }

        public RecordNotFoundException(long id)
            : base(String.Format("Record not found with Id: {0}", id))
        {

        }
        
    }
}
