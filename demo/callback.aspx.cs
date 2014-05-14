using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LoginRadius.SDK;
using LoginRadius.SDK.API;
using LoginRadius.SDK.Models.UserProfile;
using LoginRadius.SDK.Models.Audio;
using LoginRadius.SDK.Models.Album;
using LoginRadius.SDK.Models.CheckIn;
using LoginRadius.SDK.Models.Company;
using LoginRadius.SDK.Models.Contact;
using LoginRadius.SDK.Models.Event;
using LoginRadius.SDK.Models.Group;
using LoginRadius.SDK.Models.Like;
using LoginRadius.SDK.Models.Page;
using LoginRadius.SDK.Models.Photo;
using LoginRadius.SDK.Models.Post;
using LoginRadius.SDK.Models.Status;
using LoginRadius.SDK.Models.Video;
using LoginRadius.SDK.Models.Mention;
using LoginRadius.SDK.Models.Following;
using LoginRadius.SDK.Models;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Web.Configuration;
using System.Configuration;


namespace LoginRadiusDemo
{
    public partial class callback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //create callback to get access token and request tokem
            LoginRadiusCallback callback = new LoginRadiusCallback();


            //If Request as LoginRadius callback, after user successfully loggedin on provider.
            if (callback.IsCallback)
            {
                //To get access token with the help of loginradius "api secret"
                var accessToken = callback.GetAccessToken(ConfigurationManager.AppSettings["apisecret"].ToString());

                //save token to session for further use
                Session["token"] = accessToken;

                try
                {
                    //create client with the help of access token as parameter
                    LoginRadiusClient client = new LoginRadiusClient(accessToken);

                    //create object to execute user profile api to get user profile data.
                    UserProfileAPI userprofile = new UserProfileAPI();

                    //To get ultimate user profile data with the help of user profile api object as parameter.
                    // and pass "LoginRadiusUltimateUserProfile" model as interface to map user profile data.
                    var userProfileData = client.GetResponse<LoginRadiusUltimateUserProfile>(userprofile);


                    if (userProfileData.Provider.ToLower() == "facebook" || userProfileData.Provider.ToLower() == "twitter" || userProfileData.Provider.ToLower() == "linkedin")
                    {
                        postmessage.Visible = true;
                    }
                    else
                    {
                        postmessage.Visible = false;
                    }
                    if (userProfileData.Provider.ToLower() == "twitter" || userProfileData.Provider.ToLower() == "linkedin")
                    {
                        directmessage.Visible = true;
                    }
                    else
                    {
                        directmessage.Visible = false;
                    }


                    name.Text = "<b>Full Name : </b>" + userProfileData.FullName;
                    if (userProfileData.Email != null)
                    {
                        emailid.Text = "<b>Email ID  : </b>" + userProfileData.Email[0].Value;
                    }
                    about.Text = "<b>About     : </b>" + userProfileData.About;
                    if (userProfileData.ImageUrl != null && userProfileData.ImageUrl != "")
                    {
                        userprofileimage.ImageUrl = userProfileData.ImageUrl;
                    }
                    else
                    {
                        userprofileimage.ImageUrl = "Content/images/no_image.png";
                    }                    

                    if(userProfileData.ID != null)
                    {
                        Truserid.Visible = true;
                    }
                    if(userProfileData.Gender != null)
                    {
                        Trgender.Visible = true;
                    }
                    if(userProfileData.Provider != null)
                    {
                        Trprovider.Visible = true;
                    }
                    if(userProfileData.ProfileName != null)
                    {
                        TrProfileName.Visible = true;
                    }
                    if(userProfileData.Age != null)
                    {
                        Trage.Visible = true;
                    }
                    if(userProfileData.Quota != null)
                    {
                        Trquota.Visible = true;
                    }
                    if(userProfileData.MainAddress != null)
                    {
                        TrMainAddress.Visible = true;
                    }
                    if(userProfileData.HomeTown != null)
                    {
                        TrHomeTown.Visible = true;
                    }
                    if(userProfileData.PhoneNumbers != null)
                    {
                        TrPhoneNumbers.Visible = true;
                    }
                    if(userProfileData.ProfileCountry != null)
                    {
                        TrProfileCountry.Visible = true;
                    }
                    if(userProfileData.ProfileUrl != null)
                    {
                        TrProfileUrl.Visible = true;
                    }
                    if(userProfileData.Religion != null)
                    {
                        TrReligion.Visible = true;
                    }
                    if(userProfileData.RelationshipStatus != null)
                    {
                        TrRelationshipStatus.Visible = true;
                    }
                    if(userProfileData.State != null)
                    {
                        TrState.Visible = true;
                    }
                     if(userProfileData.TimeZone != null)
                    {
                        Trtimezone.Visible = true;
                    }
                   if(userProfileData.LocalLanguage != null)
                    {
                        Trlocallanguage.Visible = true;
                    }
                    if(userProfileData.Website != null)
                    {
                        Trwebsite.Visible = true;
                    }
                    if(userProfileData.BirthDate != null)
                    {
                        Trdateofbirth.Visible = true;
                    }

                    gender.Text = userProfileData.Gender;
                    age.Text = userProfileData.Age;
                    dateofbirth.Text = userProfileData.BirthDate;
                    website.Text = userProfileData.Website;
                    locallanguage.Text = userProfileData.LocalLanguage;
                    timezone.Text = userProfileData.TimeZone;
                    State.Text = userProfileData.State;
                    RelationshipStatus.Text = userProfileData.RelationshipStatus;
                    Religion.Text = userProfileData.Religion;
                    ProfileCountry.Text = userProfileData.ProfileCountry;
                    ProfileUrl.Text = userProfileData.ProfileUrl;
                    HomeTown.Text = userProfileData.HomeTown;
                    MainAddress.Text = userProfileData.MainAddress;
                    userid.Text = userProfileData.ID;
                    provider.Text = userProfileData.Provider;
                    localcity.Text = userProfileData.LocalCity;
                    localcountry.Text = userProfileData.LocalCountry;
                    ProfileName.Text = userProfileData.ProfileName;
                    quota.Text = userProfileData.Quota;

                    if (userProfileData.Addresses != null)
                    {
                        address.Visible = true;
                    }
                    if (userProfileData.Positions != null)
                    {
                        position.Visible = true;
                    }
                    if (userProfileData.Educations != null)
                    {
                        educationss.Visible = true;
                    }
                    positions.DataSource = userProfileData.Positions;
                    positions.DataBind();
                    educations.DataSource = userProfileData.Educations;
                    educations.DataBind();
                    addresses.DataSource = userProfileData.Addresses;
                    addresses.DataBind();


                    //create object to execute album api to get albums
                    AlbumAPI albums = new AlbumAPI();

                    //To get albums data with the help of album api object as parameter.
                    // and pass "LoginRadiusAlbum" model as interface to map album data.
                    var userAlbums = client.GetResponse<List<LoginRadiusAlbum>>(albums);
                    Album.DataSource = userAlbums != null ? userAlbums : null;
                    Album.DataBind();

                    //create object to execute audio api to get audios
                    AudioAPI audios = new AudioAPI();

                    //To get audios data with the help of audio api object as parameter.
                    // and pass "LoginRadiusAudio" model as interface to map audio data.                    
                    var userAudios = client.GetResponse<List<LoginRadiusAudio>>(audios);
                    Audio.DataSource = userAudios != null ? userAudios : null;
                    Audio.DataBind();

                    //create object to execute checkin api to get checkins
                    CheckInAPI checkins = new CheckInAPI();

                    //To get checkins data with the help of checkin api object as parameter.
                    // and pass "LoginRadiusCheckIn" model as interface to map checkin data.
                    var userCheckins = client.GetResponse<List<LoginRadiusCheckIn>>(checkins);
                    CheckIn.DataSource = userCheckins != null ? userCheckins : null;
                    CheckIn.DataBind();

                    //create object to execute company api to get companies
                    CompanyAPI companies = new CompanyAPI();

                    //To get companies data with the help of company api object as parameter.
                    // and pass "LoginRadiusCompany" model as interface to map company data.
                    var userCompanies = client.GetResponse<List<LoginRadiusCompany>>(companies);
                    Company.DataSource = userCompanies != null ? userCompanies : null;
                    Company.DataBind();

                    //create object to execute contact api to get contacts
                    ContactAPI contacts = new ContactAPI();

                    //To get contacts data with the help of contact api object as parameter.
                    // and pass "LoginRadiusContact" model as interface to map contact data.
                    var userContacts = client.GetResponse<LoginRadiusCursorResponse<LoginRadiusContact>>(contacts);

                    Contact.DataSource = userContacts != null ? userContacts.Data : null;
                    Contact.DataBind();

                    //create object to execute event api to get events
                    EventAPI events = new EventAPI();

                    //To get events data with the help of event api object as parameter.
                    // and pass "LoginRadiusEvent" model as interface to map event data.
                    var userEvents = client.GetResponse<List<LoginRadiusEvent>>(events);
                    Event.DataSource = userEvents != null ? userEvents : null;
                    Event.DataBind();

                    //create object to execute following api to get followings
                    FollowingAPI followings = new FollowingAPI();

                    //To get followings data with the help of following api object as parameter.
                    // and pass "LoginRadiusFollowing" model as interface to map following data.
                    var userFollowings = client.GetResponse<List<LoginRadiusFollowing>>(followings);
                    Following.DataSource = userFollowings != null ? userFollowings : null;
                    Following.DataBind();

                    //create object to execute group api to get groups
                    GroupAPI groups = new GroupAPI();

                    //To get groups data with the help of group api object as parameter.
                    // and pass "LoginRadiusGroup" model as interface to map group data.
                    var userGroups = client.GetResponse<List<LoginRadiusGroup>>(groups);
                    Group.DataSource = userGroups != null ? userGroups : null;
                    Group.DataBind();

                    //create object to execute like api to get likes
                    LikeAPI likes = new LikeAPI();

                    //To get likes data with the help of like api object as parameter.
                    // and pass "LoginRadiusLike" model as interface to map like data.
                    var userLikes = client.GetResponse<List<LoginRadiusLike>>(likes);
                    Like.DataSource = userLikes != null ? userLikes : null;
                    Like.DataBind();


                    //create object to execute mention api to get mentions
                    MentionAPI mentions = new MentionAPI();

                    //To get mentions data with the help of mention api object as parameter.
                    // and pass "LoginRadiusMention" model as interface to map mention data.
                    var userMentions = client.GetResponse<List<LoginRadiusMention>>(mentions);
                    Mention.DataSource = userMentions != null ? userMentions : null;
                    Mention.DataBind();

                    //create object to execute page api to get pages
                    PageAPI pages = new PageAPI();

                    //To get pages data with the help of page api object as parameter.
                    // and pass "LoginRadiusPage" model as interface to map page data.
                    var userPages = client.GetResponse<List<LoginRadiusPage>>(pages);
                    Pages.DataSource = userPages != null ? userPages : null;
                    Pages.DataBind();

                    //create object to execute photo api to get photos
                    PhotoAPI photos = new PhotoAPI();

                    //To get photos data with the help of photo api object as parameter.
                    // and pass "LoginRadiusPhoto" model as interface to map photo data.
                    var userPhotos = client.GetResponse<List<LoginRadiusPhoto>>(photos);
                    Photo.DataSource = userPhotos != null ? userPhotos : null;
                    Photo.DataBind();

                    //create object to execute post api to get posts
                    PostAPI posts = new PostAPI();

                    //To get posts data with the help of post api object as parameter.
                    // and pass "LoginRadiusPost" model as interface to map post data.
                    var userPosts = client.GetResponse<List<LoginRadiusPost>>(posts);
                    Post.DataSource = userPosts != null ? userPosts : null;
                    Post.DataBind();

                    //create object to execute status api to get statuses
                    StatusAPI statuses = new StatusAPI();

                    //To get statuses data with the help of status api object as parameter.
                    // and pass "LoginRadiusStatus" model as interface to map status data.
                    var userStatuses = client.GetResponse<List<LoginRadiusStatus>>(statuses);
                    Statuses.DataSource = userStatuses != null ? userStatuses : null;
                    Statuses.DataBind();

                    //create object to execute video api to get videos
                    VideoAPI videos = new VideoAPI();

                    //To get videos data with the help of video api object as parameter.
                    // and pass "LoginRadiusVideo" model as interface to map video data.
                    var userVideos = client.GetResponse<List<LoginRadiusVideo>>(videos);
                    Video.DataSource = userVideos != null ? userVideos : null;
                    Video.DataBind();

                }
                catch (Exception ee)
                {
                    Response.Write(ee.StackTrace);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //create client with the help of access token as parameter which is stored in session.
            LoginRadiusClient client = new LoginRadiusClient((LoginRadiusAccessToken)Session["token"]);

            //create object to execute status update api to post status on facebook, twitter and linkedin
            StatusUpdateAPI statusUpdate = new StatusUpdateAPI();


            //fill fields to update status
            statusUpdate.Title = title.Text;
            statusUpdate.Status = Status.Text;
            statusUpdate.Imageurl = Imageurl.Text;
            statusUpdate.Url = Url.Text;
            statusUpdate.Caption = Caption.Text;
            statusUpdate.Description = Description.Text;

            // post status on facebook, twitter and linkedin with the help of status update object as parameter
            //pass LoginRadiusPostResponse model as interface to map loginradius post response.
            var response = client.GetResponse<LoginRadiusPostResponse>(statusUpdate);
            if (response.isPosted == true)
            {
                ispost.InnerText = "Successfully posted!!";
            }
            else
            {
                ispost.InnerText = "Not posted!!";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //create client with the help of access token as parameter which is stored in session.
            LoginRadiusClient client = new LoginRadiusClient((LoginRadiusAccessToken)Session["token"]);

            //create object to execute message api to send message on twitter and linkedin
            MessageAPI sendMessage = new MessageAPI();

            //fill fields to send message
            sendMessage.To = to.Text;
            sendMessage.Subject = subject.Text;
            sendMessage.Message = message.Text;

            // send message on twitter and linkedin with the help of MessageAPI object as parameter
            //pass LoginRadiusPostResponse model as interface to map loginradius post response.
            var response = client.GetResponse<LoginRadiusPostResponse>(sendMessage);

            if (response.isPosted == true)
            {
                issend.InnerText = "Successfully sent!!";
            }
            else
            {
                issend.InnerText = "Not sent!!";
            }

        }
    }
}