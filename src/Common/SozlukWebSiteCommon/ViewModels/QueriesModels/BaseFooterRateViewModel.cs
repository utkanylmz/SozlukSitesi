using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSiteCommon.ViewModels.QueriesModels
{
    public class BaseFooterRateViewModel
    {
        public VoteType VoteType { get; set; }

    }
     
    public class BaseFooterFavoriteViewModel
    {
        public bool IsFavorited { get; set; }
        public int FavoritedCount { get; set; }
    }

    public class BaseFooterRateFavoriteViewModel : BaseFooterFavoriteViewModel
    {
        public VoteType VoteType { get; set; }
    }

}
