﻿using CRM.BLL.DTO;
using CRM.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CRM.BLL.Service
{
    public class IndPersonService: ContragentService<IndividualPerson>
    {
        public IndPersonService(string constring) : base(constring)
        {

        }

        public override IEnumerable<IndividualPerson> GetAll(bool type)
        {
           try
            {
                if (repository.GetAll() != null)
                    if (type)
                        return repository.GetAll().OrderBy(x => x.LastName).ThenBy(x => x.Name).ThenBy(x => x.SecondName);
                    else
                        return repository.GetAll();
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

    }
}
