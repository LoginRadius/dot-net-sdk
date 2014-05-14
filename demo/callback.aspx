<%@ Page Title="User Profile Data" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="callback.aspx.cs" Inherits="LoginRadiusDemo.callback" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="userprofileimage" runat="server" Height="224px" Width="197px" />
            </td>
            <td>
                <asp:Label ID="name" runat="server"></asp:Label>
                <br />
                <asp:Label ID="emailid" runat="server"></asp:Label>
                <br />
                <asp:Label ID="about" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table>
                    <tr id="Truserid" runat="server" visible="false">
                        <td>
                            <b>ID</b>
                        </td>
                        <td>
                            <asp:Label ID="userid" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trprovider" runat="server" visible="false">
                        <td>
                            <b>Provider</b>
                        </td>
                        <td>
                            <asp:Label ID="provider" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trquota" runat="server" visible="false">
                        <td>
                            <b>Quota</b>
                        </td>
                        <td>
                            <asp:Label ID="quota" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trgender" runat="server" visible="false">
                        <td>
                            <b>Gender</b>
                        </td>
                        <td>
                            <asp:Label ID="gender" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trdateofbirth" runat="server" visible="false">
                        <td>
                            <b>Date of Birth</b>
                        </td>
                        <td>
                            <asp:Label ID="dateofbirth" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trage" runat="server" visible="false">
                        <td>
                            <b>Age</b>
                        </td>
                        <td>
                            <asp:Label ID="age" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trlocallanguage" runat="server" visible="false">
                        <td>
                            <b>Local Language</b>
                        </td>
                        <td>
                            <asp:Label ID="locallanguage" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trtimezone" runat="server" visible="false">
                        <td>
                            <b>Time Zone</b>
                        </td>
                        <td>
                            <asp:Label ID="timezone" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trwebsite" runat="server" visible="false">
                        <td>
                            <b>Website</b>
                        </td>
                        <td>
                            <asp:Label ID="website" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trlocalcity" runat="server" visible="false">
                        <td>
                            <b>Local City</b>
                        </td>
                        <td>
                            <asp:Label ID="localcity" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrCity" runat="server" visible="false">
                        <td>
                            <b>City</b>
                        </td>
                        <td>
                            <asp:Label ID="City" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trlocalcountry" runat="server" visible="false">
                        <td>
                            <b>Local Country</b>
                        </td>
                        <td>
                            <asp:Label ID="localcountry" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrCountry" runat="server" visible="false">
                        <td>
                            <b>Country</b>
                        </td>
                        <td>
                            <asp:Label ID="Country" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrCreated" runat="server" visible="false">
                        <td>
                            <b>Created</b>
                        </td>
                        <td>
                            <asp:Label ID="Created" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrCurrency" runat="server" visible="false">
                        <td>
                            <b>Currency</b>
                        </td>
                        <td>
                            <asp:Label ID="Currency" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrCurrentStatus" runat="server" visible="false">
                        <td>
                            <b>Current Status</b>
                        </td>
                        <td>
                            <asp:Label ID="CurrentStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrFollowersCount" runat="server" visible="false">
                        <td>
                            <b>Followers Count</b>
                        </td>
                        <td>
                            <asp:Label ID="FollowersCount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrFriendsCount" runat="server" visible="false">
                        <td>
                            <b>Friends Count</b>
                        </td>
                        <td>
                            <asp:Label ID="FriendsCount" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrState" runat="server" visible="false">
                        <td>
                            <b>State</b>
                        </td>
                        <td>
                            <asp:Label ID="State" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrRelationshipStatus" runat="server" visible="false">
                        <td>
                            <b>Relationship Status</b>
                        </td>
                        <td>
                            <asp:Label ID="RelationshipStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrReligion" runat="server" visible="false">
                        <td>
                            <b>Religion</b>
                        </td>
                        <td>
                            <asp:Label ID="Religion" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrProfileName" runat="server" visible="false">
                        <td>
                            <b>Profile Name</b>
                        </td>
                        <td>
                            <asp:Label ID="ProfileName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrProfileCountry" runat="server" visible="false">
                        <td>
                            <b>Profile Country</b>
                        </td>
                        <td>
                            <asp:Label ID="ProfileCountry" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrProfileUrl" runat="server" visible="false">
                        <td>
                            <b>Profile Url</b>
                        </td>
                        <td>
                            <asp:Label ID="ProfileUrl" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="Trupdatedtime" runat="server" visible="false">
                        <td>
                            <b>Updated Time</b>
                        </td>
                        <td>
                            <asp:Label ID="updatedtime" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrPhoneNumbers" runat="server" visible="false">
                        <td>
                            <b>Phone Numbers</b>
                        </td>
                        <td>
                            <asp:Label ID="PhoneNumbers" runat="server"></asp:Label>
                        </td>
                    </tr>
                   <tr id="TrHomeTown" runat="server" visible="false">
                        <td>
                            <b>Home Town</b>
                        </td>
                        <td>
                            <asp:Label ID="HomeTown" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="TrMainAddress" runat="server" visible="false">
                        <td>
                            <b>Main Address</b>
                        </td>
                        <td>
                            <asp:Label ID="MainAddress" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>
                <br />
                <br />
                <div id="educationss" runat="server" visible="false"><b>Educations</b></div>
                <asp:GridView runat="server" ID="educations">
                </asp:GridView>
                <br />
                <div id="position" runat="server" visible="false"><b>Positions</b></div>
                <asp:GridView runat="server" ID="positions">
                </asp:GridView>
                <br />
                <div id="address" runat="server" visible="false"><b>Addresses</b></div>
                <asp:GridView runat="server" ID="addresses">
                </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>
        <td></td>
        </tr>
    </table>
    <table id="postmessage" runat="server">
        <tr>
            <td>
                <b>Post Status :</b>
            </td>
            <td>
                <b><span id="ispost" runat="server"></span></b>
            </td>
        </tr>
        <tr>
            <td>
                Title
            </td>
            <td>
                <asp:TextBox ID="title" runat="server" Width="500" Height="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Url
            </td>
            <td>
                <asp:TextBox ID="Url" runat="server" Width="500" Height="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Imageurl
            </td>
            <td>
                <asp:TextBox ID="Imageurl" runat="server" Width="500" Height="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Status
            </td>
            <td>
                <asp:TextBox ID="Status" runat="server" Width="500" Height="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Caption
            </td>
            <td>
                <asp:TextBox ID="Caption" runat="server" Width="500" Height="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Description
            </td>
            <td>
                <asp:TextBox ID="Description" runat="server" Width="500" Height="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Post Status" OnClick="Button1_Click" />
            </td>
        </tr>
    </table>
    <table id="directmessage" runat="server">
       <tr>
       <td><b> Send Message : </b>
       </td>
       <td>
       <b><span ID="issend" runat="server"></span></b>
       </td>
       </tr>
        <tr>
            <td>
                To 
            </td>
            <td>
               <asp:TextBox ID="to" runat="server" Width="500" Height="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Subject
            </td>
            <td>
                <asp:TextBox ID="subject" runat="server" Width="500" Height="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                 Message
            </td>
            <td>
                <asp:TextBox ID="message" runat="server" Width="500" Height="20" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="sendmessage" runat="server" Text="Send Message" OnClick="Button2_Click" />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <b>Albums</b><br />
                <asp:GridView ID="Album" runat="server">
                </asp:GridView>
                <b>Audios</b><br />
                <asp:GridView ID="Audio" runat="server">
                </asp:GridView>
                <b>CheckIn</b><br />
                <asp:GridView ID="CheckIn" runat="server">
                </asp:GridView>
                <b>Companies</b><br />
                <asp:GridView ID="Company" runat="server">
                </asp:GridView>
                <b>Contacts</b><br />
                <asp:GridView ID="Contact" runat="server">
                </asp:GridView>
                <b>Events</b><br />
                <asp:GridView ID="Event" runat="server">
                </asp:GridView>
                <b>Followings</b><br />
                <asp:GridView ID="Following" runat="server">
                </asp:GridView>
                <b>Groups</b><br />
                <asp:GridView ID="Group" runat="server">
                </asp:GridView>
                <b>Likes</b><br />
                <asp:GridView ID="Like" runat="server">
                </asp:GridView>
                <b>Mentions</b><br />
                <asp:GridView ID="Mention" runat="server">
                </asp:GridView>
                <b>Pages</b><br />
                <asp:GridView ID="Pages" runat="server">
                </asp:GridView>
                <b>Photos</b><br />
                <asp:GridView ID="Photo" runat="server">
                </asp:GridView>
                <b>Posts</b><br />
                <asp:GridView ID="Post" runat="server">
                </asp:GridView>
                <b>Statuses</b><br />
                <asp:GridView ID="Statuses" runat="server">
                </asp:GridView>
                <b>Videos</b><br />
                <asp:GridView ID="Video" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
