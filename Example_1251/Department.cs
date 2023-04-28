namespace Example_1251
{
    public class Department 
    {
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }

        public Department(string Name, int Id)
        {
            DepartmentName = Name;
            DepartmentId = Id;
        }

        //public override string ToString()
        //{
        //    return $"{DepartmentName,15} {DepartmentId,3}";
        //}
    }
}
