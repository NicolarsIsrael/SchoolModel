using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolModel.Data.Contracts
{
    public interface IUnitOfWork
    {
        
        void Save();
    }
}
