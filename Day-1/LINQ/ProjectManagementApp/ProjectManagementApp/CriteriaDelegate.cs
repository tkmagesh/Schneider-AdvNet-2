namespace ProjectManagementApp
{
    /*public delegate int IntAttributeSelectorDelegate<T>(T item);
    public delegate decimal DecimalAttributeSelectorDelegate<T>(T item);
    */

    public delegate bool CriteriaDelegate<T>(T item);
}