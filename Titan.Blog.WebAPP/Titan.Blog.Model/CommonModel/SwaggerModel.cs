/************************************************************************
 * 文件名：SwaggerModel
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/4 15:03:03
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Blog.Model.CommonModel
{
    public class SwaggerModel
    {

        public class Rootobject
        {
            public string swagger { get; set; }
            public Info info { get; set; }
            public Paths paths { get; set; }
            public Definitions definitions { get; set; }
            public Securitydefinitions securityDefinitions { get; set; }
            public Security[] security { get; set; }
            public Tag[] tags { get; set; }
        }

        public class Info
        {
            public string version { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public string termsOfService { get; set; }
            public Contact contact { get; set; }
        }

        public class Contact
        {
            public string name { get; set; }
            public string url { get; set; }
            public string email { get; set; }
        }

        public class Paths
        {
            public ApiV2AuthorizationLoginv2 apiv2AuthorizationLoginV2 { get; set; }
            public ApiV2AuthorizationFuck apiv2AuthorizationFuck { get; set; }
            public ApiV2AuthorizationFuckId apiv2AuthorizationFuckid { get; set; }
            public ApiV2FiletestUploadfile apiv2FileTestUploadFile { get; set; }
            public ApiV2FiletestUploadfilebyname apiv2FileTestUploadFileByName { get; set; }
            public ApiV2FiletestUploadfilelist apiv2FileTestUploadFileList { get; set; }
            public ApiV2FiletestDownloadfileFilename apiv2FileTestDownloadFilefileName { get; set; }
            public ApiV2ImagetestGetimageId apiv2ImageTestGetImageid { get; set; }
            public ApiV2ImagetestEfcoretest apiv2ImageTestEFCoreTest { get; set; }
            public ApiV2ManyrulePostform apiv2ManyRulePostForm { get; set; }
            public ApiV2TestZarraytest apiv2TestZArrayTest { get; set; }
            public ApiV2TestBloglist apiv2TestBlogList { get; set; }
            public ApiV2TestBloglistId apiv2TestBlogListid { get; set; }
            public ApiV2TestAddblog apiv2TestAddBlog { get; set; }
            public ApiV2TestUpdateblogId apiv2TestUpdateBlogid { get; set; }
            public ApiV2TestDeleteblogId apiv2TestDeleteBlogid { get; set; }
            public ApiV2TestHiddentestIdName apiv2TestHiddenTestidname { get; set; }
            public ApiV2TestFormheader apiv2TestFormHeader { get; set; }
        }

        public class ApiV2AuthorizationLoginv2
        {
            public Get get { get; set; }
        }

        public class Get
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string description { get; set; }
            public string operationId { get; set; }
            public object[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter[] parameters { get; set; }
            public Responses responses { get; set; }
        }

        public class Responses
        {
            public _200 _200 { get; set; }
        }

        public class _200
        {
            public string description { get; set; }
            public Schema schema { get; set; }
        }

        public class Schema
        {
            public string _ref { get; set; }
        }

        public class Parameter
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class ApiV2AuthorizationFuck
        {
            public Get1 get { get; set; }
        }

        public class Get1
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public object[] consumes { get; set; }
            public string[] produces { get; set; }
            public object[] parameters { get; set; }
            public Responses1 responses { get; set; }
        }

        public class Responses1
        {
            public _2001 _200 { get; set; }
        }

        public class _2001
        {
            public string description { get; set; }
            public Schema1 schema { get; set; }
        }

        public class Schema1
        {
            public string _ref { get; set; }
        }

        public class ApiV2AuthorizationFuckId
        {
            public Get2 get { get; set; }
        }

        public class Get2
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public object[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter1[] parameters { get; set; }
            public Responses2 responses { get; set; }
        }

        public class Responses2
        {
            public _2002 _200 { get; set; }
        }

        public class _2002
        {
            public string description { get; set; }
            public Schema2 schema { get; set; }
        }

        public class Schema2
        {
            public string _ref { get; set; }
        }

        public class Parameter1
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
            public string format { get; set; }
        }

        public class ApiV2FiletestUploadfile
        {
            public Post post { get; set; }
        }

        public class Post
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter2[] parameters { get; set; }
            public Responses3 responses { get; set; }
        }

        public class Responses3
        {
            public _2003 _200 { get; set; }
        }

        public class _2003
        {
            public string description { get; set; }
            public Schema3 schema { get; set; }
        }

        public class Schema3
        {
            public string _ref { get; set; }
        }

        public class Parameter2
        {
            public string name { get; set; }
            public string _in { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class ApiV2FiletestUploadfilebyname
        {
            public Post1 post { get; set; }
        }

        public class Post1
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter3[] parameters { get; set; }
            public Responses4 responses { get; set; }
        }

        public class Responses4
        {
            public _2004 _200 { get; set; }
        }

        public class _2004
        {
            public string description { get; set; }
            public Schema4 schema { get; set; }
        }

        public class Schema4
        {
            public string _ref { get; set; }
        }

        public class Parameter3
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class ApiV2FiletestUploadfilelist
        {
            public Post2 post { get; set; }
        }

        public class Post2
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter4[] parameters { get; set; }
            public Responses5 responses { get; set; }
        }

        public class Responses5
        {
            public _2005 _200 { get; set; }
        }

        public class _2005
        {
            public string description { get; set; }
            public Schema5 schema { get; set; }
        }

        public class Schema5
        {
            public string _ref { get; set; }
        }

        public class Parameter4
        {
            public string name { get; set; }
            public string _in { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
            public Items items { get; set; }
            public string collectionFormat { get; set; }
            public bool uniqueItems { get; set; }
        }

        public class Items
        {
        }

        public class ApiV2FiletestDownloadfileFilename
        {
            public Post3 post { get; set; }
        }

        public class Post3
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public object[] produces { get; set; }
            public Parameter5[] parameters { get; set; }
            public Responses6 responses { get; set; }
        }

        public class Responses6
        {
            public _2006 _200 { get; set; }
        }

        public class _2006
        {
            public string description { get; set; }
        }

        public class Parameter5
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class ApiV2ImagetestGetimageId
        {
            public Get3 get { get; set; }
        }

        public class Get3
        {
            public string[] tags { get; set; }
            public string operationId { get; set; }
            public object[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter6[] parameters { get; set; }
            public Responses7 responses { get; set; }
        }

        public class Responses7
        {
            public _2007 _200 { get; set; }
        }

        public class _2007
        {
            public string description { get; set; }
            public Schema6 schema { get; set; }
        }

        public class Schema6
        {
            public string _ref { get; set; }
        }

        public class Parameter6
        {
            public string name { get; set; }
            public string _in { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class ApiV2ImagetestEfcoretest
        {
            public Post4 post { get; set; }
        }

        public class Post4
        {
            public string[] tags { get; set; }
            public string description { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter7[] parameters { get; set; }
            public Responses8 responses { get; set; }
        }

        public class Responses8
        {
            public _2008 _200 { get; set; }
        }

        public class _2008
        {
            public string description { get; set; }
            public Schema7 schema { get; set; }
        }

        public class Schema7
        {
            public string _ref { get; set; }
        }

        public class Parameter7
        {
            public string name { get; set; }
            public string _in { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class ApiV2ManyrulePostform
        {
            public Post5 post { get; set; }
        }

        public class Post5
        {
            public string[] tags { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter8[] parameters { get; set; }
            public Responses9 responses { get; set; }
        }

        public class Responses9
        {
            public _2009 _200 { get; set; }
        }

        public class _2009
        {
            public string description { get; set; }
            public Schema8 schema { get; set; }
        }

        public class Schema8
        {
            public string _ref { get; set; }
        }

        public class Parameter8
        {
            public string name { get; set; }
            public string _in { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
            public Items1 items { get; set; }
            public string collectionFormat { get; set; }
            public bool uniqueItems { get; set; }
        }

        public class Items1
        {
            public string type { get; set; }
            public string format { get; set; }
        }

        public class ApiV2TestZarraytest
        {
            public Post6 post { get; set; }
        }

        public class Post6
        {
            public string[] tags { get; set; }
            public string description { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter9[] parameters { get; set; }
            public Responses10 responses { get; set; }
        }

        public class Responses10
        {
            public _20010 _200 { get; set; }
        }

        public class _20010
        {
            public string description { get; set; }
            public Schema9 schema { get; set; }
        }

        public class Schema9
        {
            public string _ref { get; set; }
        }

        public class Parameter9
        {
            public string name { get; set; }
            public string _in { get; set; }
            public bool required { get; set; }
            public Schema10 schema { get; set; }
        }

        public class Schema10
        {
            public bool uniqueItems { get; set; }
            public string type { get; set; }
            public Items2 items { get; set; }
        }

        public class Items2
        {
            public string type { get; set; }
        }

        public class ApiV2TestBloglist
        {
            public Get4 get { get; set; }
        }

        public class Get4
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string description { get; set; }
            public string operationId { get; set; }
            public object[] consumes { get; set; }
            public string[] produces { get; set; }
            public object[] parameters { get; set; }
            public Responses11 responses { get; set; }
        }

        public class Responses11
        {
            public _20011 _200 { get; set; }
        }

        public class _20011
        {
            public string description { get; set; }
            public Schema11 schema { get; set; }
        }

        public class Schema11
        {
            public string _ref { get; set; }
        }

        public class ApiV2TestBloglistId
        {
            public Get5 get { get; set; }
            public Post7 post { get; set; }
        }

        public class Get5
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public object[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter10[] parameters { get; set; }
            public Responses12 responses { get; set; }
        }

        public class Responses12
        {
            public _20012 _200 { get; set; }
        }

        public class _20012
        {
            public string description { get; set; }
            public Schema12 schema { get; set; }
        }

        public class Schema12
        {
            public string _ref { get; set; }
        }

        public class Parameter10
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class Post7
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter11[] parameters { get; set; }
            public Responses13 responses { get; set; }
        }

        public class Responses13
        {
            public _20013 _200 { get; set; }
        }

        public class _20013
        {
            public string description { get; set; }
            public Schema13 schema { get; set; }
        }

        public class Schema13
        {
            public string _ref { get; set; }
        }

        public class Parameter11
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class ApiV2TestAddblog
        {
            public Post8 post { get; set; }
        }

        public class Post8
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter12[] parameters { get; set; }
            public Responses14 responses { get; set; }
        }

        public class Responses14
        {
            public _20014 _200 { get; set; }
        }

        public class _20014
        {
            public string description { get; set; }
            public Schema14 schema { get; set; }
        }

        public class Schema14
        {
            public string _ref { get; set; }
        }

        public class Parameter12
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public Schema15 schema { get; set; }
        }

        public class Schema15
        {
            public string _ref { get; set; }
        }

        public class ApiV2TestUpdateblogId
        {
            public Put put { get; set; }
        }

        public class Put
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter13[] parameters { get; set; }
            public Responses15 responses { get; set; }
        }

        public class Responses15
        {
            public _20015 _200 { get; set; }
        }

        public class _20015
        {
            public string description { get; set; }
            public Schema16 schema { get; set; }
        }

        public class Schema16
        {
            public string _ref { get; set; }
        }

        public class Parameter13
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
            public string format { get; set; }
            public Schema17 schema { get; set; }
        }

        public class Schema17
        {
            public string _ref { get; set; }
        }

        public class ApiV2TestDeleteblogId
        {
            public Delete delete { get; set; }
        }

        public class Delete
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string operationId { get; set; }
            public object[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter14[] parameters { get; set; }
            public Responses16 responses { get; set; }
        }

        public class Responses16
        {
            public _20016 _200 { get; set; }
        }

        public class _20016
        {
            public string description { get; set; }
            public Schema18 schema { get; set; }
        }

        public class Schema18
        {
            public string _ref { get; set; }
        }

        public class Parameter14
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
            public string format { get; set; }
        }

        public class ApiV2TestHiddentestIdName
        {
            public Get6 get { get; set; }
            public Put1 put { get; set; }
        }

        public class Get6
        {
            public string[] tags { get; set; }
            public string description { get; set; }
            public string operationId { get; set; }
            public object[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter15[] parameters { get; set; }
            public Responses17 responses { get; set; }
        }

        public class Responses17
        {
            public _20017 _200 { get; set; }
        }

        public class _20017
        {
            public string description { get; set; }
            public Schema19 schema { get; set; }
        }

        public class Schema19
        {
            public string _ref { get; set; }
        }

        public class Parameter15
        {
            public string name { get; set; }
            public string _in { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class Put1
        {
            public string[] tags { get; set; }
            public string description { get; set; }
            public string operationId { get; set; }
            public string[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter16[] parameters { get; set; }
            public Responses18 responses { get; set; }
        }

        public class Responses18
        {
            public _20018 _200 { get; set; }
        }

        public class _20018
        {
            public string description { get; set; }
            public Schema20 schema { get; set; }
        }

        public class Schema20
        {
            public string _ref { get; set; }
        }

        public class Parameter16
        {
            public string name { get; set; }
            public string _in { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class ApiV2TestFormheader
        {
            public Get7 get { get; set; }
        }

        public class Get7
        {
            public string[] tags { get; set; }
            public string summary { get; set; }
            public string description { get; set; }
            public string operationId { get; set; }
            public object[] consumes { get; set; }
            public string[] produces { get; set; }
            public Parameter17[] parameters { get; set; }
            public Responses19 responses { get; set; }
        }

        public class Responses19
        {
            public _20019 _200 { get; set; }
        }

        public class _20019
        {
            public string description { get; set; }
            public Schema21 schema { get; set; }
        }

        public class Schema21
        {
            public string _ref { get; set; }
        }

        public class Parameter17
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string description { get; set; }
            public bool required { get; set; }
            public string type { get; set; }
        }

        public class Definitions
        {
            public OpresultString OpResultString { get; set; }
            public OpresultListObject OpResultListObject { get; set; }
            public Iformfile IFormFile { get; set; }
            public Httpresponsemessage HttpResponseMessage { get; set; }
            public Version1 Version { get; set; }
            public Httpcontent HttpContent { get; set; }
            public KeyvaluepairStringIenumerableString KeyValuePairStringIEnumerableString { get; set; }
            public Httprequestmessage HttpRequestMessage { get; set; }
            public Httpmethod HttpMethod { get; set; }
            public OpresultListAuthor OpResultListAuthor { get; set; }
            public Author Author { get; set; }
            public Children Children { get; set; }
            public Xmlmodel XmlModel { get; set; }
        }

        public class OpresultString
        {
            public string type { get; set; }
            public Properties properties { get; set; }
        }

        public class Properties
        {
            public Successed successed { get; set; }
            public Message message { get; set; }
            public Resulttype resultType { get; set; }
            public Data data { get; set; }
        }

        public class Successed
        {
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Message
        {
            public string type { get; set; }
        }

        public class Resulttype
        {
            public string format { get; set; }
            public int[] _enum { get; set; }
            public string type { get; set; }
        }

        public class Data
        {
            public string type { get; set; }
        }

        public class OpresultListObject
        {
            public string type { get; set; }
            public Properties1 properties { get; set; }
        }

        public class Properties1
        {
            public Successed1 successed { get; set; }
            public Message1 message { get; set; }
            public Resulttype1 resultType { get; set; }
            public Data1 data { get; set; }
        }

        public class Successed1
        {
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Message1
        {
            public string type { get; set; }
        }

        public class Resulttype1
        {
            public string format { get; set; }
            public int[] _enum { get; set; }
            public string type { get; set; }
        }

        public class Data1
        {
            public bool uniqueItems { get; set; }
            public string type { get; set; }
            public Items3 items { get; set; }
        }

        public class Items3
        {
            public string type { get; set; }
        }

        public class Iformfile
        {
            public string type { get; set; }
            public Properties2 properties { get; set; }
        }

        public class Properties2
        {
            public Contenttype contentType { get; set; }
            public Contentdisposition contentDisposition { get; set; }
            public Headers headers { get; set; }
            public Length length { get; set; }
            public Name name { get; set; }
            public Filename fileName { get; set; }
        }

        public class Contenttype
        {
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Contentdisposition
        {
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Headers
        {
            public string type { get; set; }
            public Additionalproperties additionalProperties { get; set; }
            public bool readOnly { get; set; }
        }

        public class Additionalproperties
        {
            public bool uniqueItems { get; set; }
            public string type { get; set; }
            public Items4 items { get; set; }
        }

        public class Items4
        {
            public string type { get; set; }
        }

        public class Length
        {
            public string format { get; set; }
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Name
        {
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Filename
        {
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Httpresponsemessage
        {
            public string type { get; set; }
            public Properties3 properties { get; set; }
        }

        public class Properties3
        {
            public Version version { get; set; }
            public Content content { get; set; }
            public Statuscode statusCode { get; set; }
            public Reasonphrase reasonPhrase { get; set; }
            public Headers1 headers { get; set; }
            public Requestmessage requestMessage { get; set; }
            public Issuccessstatuscode isSuccessStatusCode { get; set; }
        }

        public class Version
        {
            public string _ref { get; set; }
        }

        public class Content
        {
            public string _ref { get; set; }
        }

        public class Statuscode
        {
            public string format { get; set; }
            public int[] _enum { get; set; }
            public string type { get; set; }
        }

        public class Reasonphrase
        {
            public string type { get; set; }
        }

        public class Headers1
        {
            public bool uniqueItems { get; set; }
            public string type { get; set; }
            public Items5 items { get; set; }
            public bool readOnly { get; set; }
        }

        public class Items5
        {
            public string _ref { get; set; }
        }

        public class Requestmessage
        {
            public string _ref { get; set; }
        }

        public class Issuccessstatuscode
        {
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Version1
        {
            public string type { get; set; }
            public Properties4 properties { get; set; }
        }

        public class Properties4
        {
            public Major major { get; set; }
            public Minor minor { get; set; }
            public Build build { get; set; }
            public Revision revision { get; set; }
            public Majorrevision majorRevision { get; set; }
            public Minorrevision minorRevision { get; set; }
        }

        public class Major
        {
            public string format { get; set; }
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Minor
        {
            public string format { get; set; }
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Build
        {
            public string format { get; set; }
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Revision
        {
            public string format { get; set; }
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Majorrevision
        {
            public string format { get; set; }
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Minorrevision
        {
            public string format { get; set; }
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Httpcontent
        {
            public string type { get; set; }
            public Properties5 properties { get; set; }
        }

        public class Properties5
        {
            public Headers2 headers { get; set; }
        }

        public class Headers2
        {
            public bool uniqueItems { get; set; }
            public string type { get; set; }
            public Items6 items { get; set; }
            public bool readOnly { get; set; }
        }

        public class Items6
        {
            public string _ref { get; set; }
        }

        public class KeyvaluepairStringIenumerableString
        {
            public string type { get; set; }
            public Properties6 properties { get; set; }
        }

        public class Properties6
        {
            public Key key { get; set; }
            public Value value { get; set; }
        }

        public class Key
        {
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Value
        {
            public bool uniqueItems { get; set; }
            public string type { get; set; }
            public Items7 items { get; set; }
            public bool readOnly { get; set; }
        }

        public class Items7
        {
            public string type { get; set; }
        }

        public class Httprequestmessage
        {
            public string type { get; set; }
            public Properties7 properties { get; set; }
        }

        public class Properties7
        {
            public Version2 version { get; set; }
            public Content1 content { get; set; }
            public Method method { get; set; }
            public Requesturi requestUri { get; set; }
            public Headers3 headers { get; set; }
            public Properties8 properties { get; set; }
        }

        public class Version2
        {
            public string _ref { get; set; }
        }

        public class Content1
        {
            public string _ref { get; set; }
        }

        public class Method
        {
            public string _ref { get; set; }
        }

        public class Requesturi
        {
            public string type { get; set; }
        }

        public class Headers3
        {
            public bool uniqueItems { get; set; }
            public string type { get; set; }
            public Items8 items { get; set; }
            public bool readOnly { get; set; }
        }

        public class Items8
        {
            public string _ref { get; set; }
        }

        public class Properties8
        {
            public string type { get; set; }
            public Additionalproperties1 additionalProperties { get; set; }
            public bool readOnly { get; set; }
        }

        public class Additionalproperties1
        {
            public string type { get; set; }
        }

        public class Httpmethod
        {
            public string type { get; set; }
            public Properties9 properties { get; set; }
        }

        public class Properties9
        {
            public Method1 method { get; set; }
        }

        public class Method1
        {
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class OpresultListAuthor
        {
            public string type { get; set; }
            public Properties10 properties { get; set; }
        }

        public class Properties10
        {
            public Successed2 successed { get; set; }
            public Message2 message { get; set; }
            public Resulttype2 resultType { get; set; }
            public Data2 data { get; set; }
        }

        public class Successed2
        {
            public string type { get; set; }
            public bool readOnly { get; set; }
        }

        public class Message2
        {
            public string type { get; set; }
        }

        public class Resulttype2
        {
            public string format { get; set; }
            public int[] _enum { get; set; }
            public string type { get; set; }
        }

        public class Data2
        {
            public bool uniqueItems { get; set; }
            public string type { get; set; }
            public Items9 items { get; set; }
        }

        public class Items9
        {
            public string _ref { get; set; }
        }

        public class Author
        {
            public string description { get; set; }
            public string type { get; set; }
            public Properties11 properties { get; set; }
        }

        public class Properties11
        {
            public Pkid pkId { get; set; }
            public Id id { get; set; }
            public Authorname authorName { get; set; }
            public Childrens childrens { get; set; }
        }

        public class Pkid
        {
            public string format { get; set; }
            public string type { get; set; }
        }

        public class Id
        {
            public string format { get; set; }
            public string type { get; set; }
        }

        public class Authorname
        {
            public string type { get; set; }
        }

        public class Childrens
        {
            public bool uniqueItems { get; set; }
            public string type { get; set; }
            public Items10 items { get; set; }
        }

        public class Items10
        {
            public string _ref { get; set; }
        }

        public class Children
        {
            public string type { get; set; }
            public Properties12 properties { get; set; }
        }

        public class Properties12
        {
            public Id1 id { get; set; }
            public Childrenid childrenid { get; set; }
            public Name1 name { get; set; }
            public Author1 author { get; set; }
        }

        public class Id1
        {
            public string format { get; set; }
            public string type { get; set; }
        }

        public class Childrenid
        {
            public string format { get; set; }
            public string type { get; set; }
        }

        public class Name1
        {
            public string type { get; set; }
        }

        public class Author1
        {
            public string _ref { get; set; }
        }

        public class Xmlmodel
        {
            public string description { get; set; }
            public string type { get; set; }
            public Properties13 properties { get; set; }
        }

        public class Properties13
        {
            public Name2 name { get; set; }
            public Value1 value { get; set; }
        }

        public class Name2
        {
            public string description { get; set; }
            public string type { get; set; }
        }

        public class Value1
        {
            public string description { get; set; }
            public string type { get; set; }
        }

        public class Securitydefinitions
        {
            public TitanBlogWebapp TitanBlogWebAPP { get; set; }
        }

        public class TitanBlogWebapp
        {
            public string name { get; set; }
            public string _in { get; set; }
            public string type { get; set; }
            public string description { get; set; }
        }

        public class Security
        {
            public object[] TitanBlogWebAPP { get; set; }
        }

        public class Tag
        {
            public string name { get; set; }
            public string description { get; set; }
        }

    }
}
