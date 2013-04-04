using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Company.Glossary.Entities;
using System.Security.Principal;

namespace Glossary.Data.Mock
{
    public static class Mock
    {
        public static List<Term> GenerateTerms()
        {
            var terms = new List<Term>();
            terms.Add(new Term() { Name = "Lorem", Definition = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Phasellus", Definition = "Phasellus a urna libero, ut vestibulum mi.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Pellentesque", Definition = "Pellentesque eu nulla risus, nec vestibulum erat.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Maecenas", Definition = "Maecenas a lorem sed libero condimentum semper.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Cras", Definition = "Cras pretium lobortis augue, eget vehicula leo laoreet quis.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Aliquam", Definition = "In at orci aliquam risus cursus convallis a non urna.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Pellentesque", Definition = "Pellentesque non leo tellus, a rhoncus lectus.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Lorem", Definition = "Quisque quis lorem et nisi aliquam semper.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Semper", Definition = "Quisque aliquet accumsan est, nec auctor purus blandit vel.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Magna", Definition = "Pellentesque sit amet odio magna, nec rhoncus lectus.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Eleifend", Definition = "Aliquam pretium tellus a purus eleifend nec consectetur mi fringilla.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Sodales", Definition = "Praesent a neque risus, at sodales lacus.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Fusce", Definition = "Fusce bibendum condimentum odio, at ultrices dolor pretium a.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Porttitor", Definition = "Quisque vestibulum porttitor mi, ac ornare quam posuere vitae.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Aenean", Definition = "Aenean vel turpis non ante euismod aliquam.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            terms.Add(new Term() { Name = "Nunc", Definition = "Nunc sed eros suscipit neque mattis luctus in ut odio.", CreatedBy = WindowsIdentity.GetCurrent().Name });
            return terms;
        }
    }
}
