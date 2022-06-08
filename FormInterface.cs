namespace PracZaliczeniowa
{
    interface IForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public void GetData();
        public void ValidateForm();
    }
}
