using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace FightClub.Repository.Implementation
{
    public class GameRepository
    {
        public user GetUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                throw new ArgumentException("invalid input","userName");

            using (var db = new fightClubEntities())
            {
                var userProfile = db.user.SingleOrDefault(a => a.username == userName);
                if (userProfile == null)
                {
                    var ava =  db.avatar.OrderBy(r => Guid.NewGuid()).First();
                    var newUser = new user
                    {
                        username = userName,
                        avatar = ava,
                        created = DateTime.Now,
                        lastModified = DateTime.Now,
                        matchesLeft = 10
                    };
                    var hest = db.user.Add(newUser);
                    db.SaveChanges();
                    return hest;
                }
                return userProfile;
            }
        }
        public IEnumerable<avatar> GetAvatars()
        {
            using (var db = new fightClubEntities())
            {
                return db.avatar.ToList();
            }
        }
        public IEnumerable<user> GetUsers()
        {
            using (var db = new fightClubEntities())
            {
                return db.user.ToList();
            }
        }
        public void CreateMatch(match match)
        {
            using (var db = new fightClubEntities())
            {
                db.match.Add(match);
            }
        }
        public void UpdateMatch(match match)
        {
            using (var db = new fightClubEntities())
            {
                var oldMatch = db.match.Single(a => a.id == match.id);
                if (oldMatch == null) return;
                oldMatch = match;
                db.SaveChanges();
            }
        }
        public void AddAvatar(avatar avatar)
        {
            using (var db = new fightClubEntities())
            {
                db.avatar.Add(avatar);
                db.SaveChanges();
            }
        }
        public user GetRandomOpponent()
        {
            using (var db = new fightClubEntities())
            {
                var opponent = db.user.OrderBy(r => Guid.NewGuid()).First();
                return opponent;
            }
        }
    }
}