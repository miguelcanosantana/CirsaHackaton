namespace CirsaHackaton.Model
{
    public class AffiliateStyle
    {
        private String id;
        private String affiliateUid;
        private String title;
        private String summary;
        private String backgroundUrl;
        private String avatarUrl;


        public AffiliateStyle(String affiliateUid, String title, String summary, string backgroundUrl, string avatarUrl)
        {
            id = Guid.NewGuid().ToString();
            this.affiliateUid = affiliateUid;
            this.title = title;
            this.summary = summary;
            this.backgroundUrl = backgroundUrl;
            this.avatarUrl = avatarUrl;
        }

        //Getters
        public String GetId() { return id; }
        public String GetAffiliateUid() { return affiliateUid; }
    }
}
