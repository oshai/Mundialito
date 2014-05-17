﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mundialito.DAL.GeneralBets
{
    public class GeneralBetsRepository : GenericRepository<GeneralBet>, IGeneralBetsRepository
    {
        public GeneralBetsRepository()
            : base(new MundialitoContext())
        {

        }

        public IEnumerable<GeneralBet> GetGeneralBets()
        {
            return Get();
        }

        public GeneralBet GetUserGeneralBet(string username)
        {
            return Context.GeneralBets.SingleOrDefault(bet => bet.User.UserName == username);
        }

        public bool IsGeneralBetExists(string userId)
        {
            return Context.GeneralBets.Any(bet => bet.User.Id == userId);
        }
               
        public GeneralBet GetGeneralBet(int betId)
        {
            return GetByID(betId);
        }

        public GeneralBet InsertGeneralBet(GeneralBet bet)
        {
            Context.Users.Attach(bet.User);
            return Insert(bet);
        }

        public void DeleteGeneralBet(int betId)
        {
            Delete(betId);
        }

        public void UpdateGeneralBet(GeneralBet bet)
        {
            Update(bet);
        }
    }
}