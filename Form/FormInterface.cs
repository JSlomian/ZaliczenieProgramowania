namespace PracZaliczeniowa.Form
{
    public interface IForm
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        void GetData();
        void ValidateForm();
    }
}
