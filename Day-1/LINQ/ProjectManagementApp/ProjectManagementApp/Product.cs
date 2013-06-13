﻿namespace ProjectManagementApp
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public int Units { get; set; }

        public int Category { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}", Id, Name, Cost, Units, Category);
            ;
        }
    }
}