namespace ContactAppBackend.Dto
{
    public class CreateContactDto
    {
        public string Title { get; set; }

        public string PhoneNumber { get; set; }

        public string Adress { get; set; }

        public string Province { get; set; }

        public string District { get; set; }

        public int OwnerId { get; set; }

    }
}
