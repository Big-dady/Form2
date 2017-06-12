using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Data
/// </summary>
public sealed class Data
{
    public string conString;
    SqlConnection sqlCon;
    SqlDataAdapter sqlAdp;
    SqlDataReader dr;
    public static DataTable batdt1;
    public static DataTable batdt2;
    public static string inno = "";
    SqlCommand cmd = new SqlCommand();
    DataSet ds;
    public static string batdate, batid;
    public static string LoginType;
    public static string query;
    public static bool loginstatus;
    public static string sessionid = "0";
    public static string session = "";
    public static string firm;
    public static int firmid;
    public static string Type;
    public static string UserId;
    public static string UserName;
    public static string repformat;
    public static string Group;
    public static string Date;
    public static string msipdno;
    public static string IPV;
    public static string Pageno;
    public static string PatientId;
    public static string usertype;
    public static string datefrom;
    public static string dateto;
    public static string year;
    public static string RepName;
    public static DataTable dt1 = new DataTable();
    public static DataTable dt2 = new DataTable();
    public static string mipdno;
    public static string query2;
    public static string uhidno;
    public static string p_name;
    public static string doctorid;
    public static string refdoctorid;
    public static string outstanding;
    public static string totalrecamount;
    public static string totalamount;
    public static string comid;
    public static string labalname;
    public static string UserType;
    public static string UserIdAdmin;
    public static string StoreId;
    public static string SaleId;
    public static string UserNameAdmin;
    public static string StoreId2;
    public static string UserStaff;
    public static string firmName;

    public Data()
    {

        //demo     
        this.conString = "Data Source=laptop;Initial Catalog=DB_VINAYAK;User Id=sa;Password=123;";

        //Live       
        //this.conString = "Data Source=HP-PC;Initial Catalog=db_BillSoftware;User Id=sa;Password=123;";

        this.sqlCon = new SqlConnection(conString);
    }

    public string ConnectionString
    {
        get { return conString; }
    }

    public SqlDataReader getDataReader(string commandString)
    {
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        if (sqlCon.State == ConnectionState.Closed)
            sqlCon.Open();
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        return dr;
    }

    public DateTime newdatetime(string strDateTime)
    {
        DateTime dtFinaldate;
        string sDateTime;
        string[] sDate = strDateTime.Split('/');
        sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
        dtFinaldate = Convert.ToDateTime(sDateTime);
        return dtFinaldate;
    }
    public bool checkMobile(string s)
    {
        try
        {
            int.Parse(s);
            return false;
        }
        catch
        {
            return true;
        }
    }
    public bool Exist(string commandString)
    {
        bool flag;
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        sqlCon.Open();
        dr = cmd.ExecuteReader();
        dr.Read();

        if (dr.HasRows)
            flag = true;
        else
            flag = false;

        dr.Close();
        sqlCon.Close();
        return flag;
    }

    public DataSet getDataSet(string commandString)
    {
        ds = new DataSet();
        sqlAdp = new SqlDataAdapter(commandString, sqlCon);
        sqlAdp.Fill(ds);
        return ds;
    }

    public DataSet getDataSet(SqlCommand command)
    {
        command.Connection = sqlCon;
        ds = new DataSet();
        sqlAdp = new SqlDataAdapter(command);
        sqlAdp.Fill(ds);
        return ds;
    }

    public int executeCommand(string commandString)
    {
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        int errStatus = 0;

        try
        {
            sqlCon.Open();
            cmd.ExecuteNonQuery();
        }
        catch
        {
            errStatus = 1;

        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public int executeCommand(string commandString, out string str)
    {
        cmd.CommandText = commandString;
        cmd.Connection = sqlCon;
        str = "";
        int errStatus = 0;

        try
        {
            sqlCon.Open();
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            errStatus = 1;
            str = ex.Message;
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public int executeCommand(SqlCommand sqlCommand)
    {
        sqlCommand.Connection = sqlCon;
        int errStatus = 0;
        try
        {
            sqlCon.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            string aa = ex.ToString();
            errStatus = 1;
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public string getDateMMDDYYYY(string dat)
    {
        string dat1 = "";
        string[] aa = dat.Split('/');
        dat1 = aa[1] + "/" + aa[0] + "/" + aa[2];
        return dat1;
    }
    public string getDateMMDDYYYY2(string dat)
    {
        string dat1 = "";
        string[] aa = dat.Split('-');
        dat1 = aa[1] + "/" + aa[0] + "/" + aa[2];
        return dat1;
    }

    public int executeCommand(SqlCommand sqlCommand, out string str)
    {
        sqlCommand.Connection = sqlCon;
        int errStatus = 0;
        str = "";
        try
        {
            sqlCon.Open();
            sqlCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            errStatus = 1;
            str = ex.Message;
        }
        finally
        {
            sqlCon.Close();
        }
        return errStatus;
    }

    public String changeNumericToWords(double numb)
    {
        String num = numb.ToString();
        return changeToWords(num, false);
    }

    public String changeCurrencyToWords(String numb)
    {
        return changeToWords(numb, true);
    }

    public String changeNumericToWords(String numb)
    {

        return changeToWords(numb, false);

    }

    public String changeCurrencyToWords(double numb)
    {

        return changeToWords(numb.ToString(), true);

    }

    private String changeToWords(String numb, bool isCurrency)
    {

        String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";

        String endStr = (isCurrency) ? ("Only") : ("");

        try
        {

            int decimalPlace = numb.IndexOf(".");

            if (decimalPlace > 0)
            {

                wholeNo = numb.Substring(0, decimalPlace);

                points = numb.Substring(decimalPlace + 1);

                if (Convert.ToInt32(points) > 0)
                {

                    andStr = (isCurrency) ? ("Point") : ("point");// just to separate whole numbers from points/cents

                    endStr = (isCurrency) ? ("" + endStr) : ("");

                    pointStr = translateCents(points);

                }

            }

            val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);

        }

        catch { ;}

        return val;

    }

    private String translateWholeNumber(String number)
    {

        string word = "";

        try
        {

            bool beginsZero = false;//tests for 0XX

            bool isDone = false;//test if already translated

            double dblAmt = (Convert.ToDouble(number));

            //if ((dblAmt > 0) && number.StartsWith("0"))

            if (dblAmt > 0)
            {//test for zero or digit zero in a nuemric

                beginsZero = number.StartsWith("0");

                int numDigits = number.Length;

                int pos = 0;//store digit grouping

                String place = "";//digit grouping name:hundres,thousand,etc...

                switch (numDigits)
                {
                    case 1://ones' range

                        word = ones(number);

                        isDone = true;

                        break;

                    case 2://tens' range

                        word = tens(number);

                        isDone = true;

                        break;

                    case 3://hundreds' range

                        pos = (numDigits % 3) + 1;

                        if (number.Substring(0, 1) != "0")
                            place = " Hundred ";

                        break;

                    case 4://thousands' range
                        pos = (numDigits % 4) + 1;
                        if (number.Substring(0, 1) != "0")
                            place = " Thousand ";
                        break;
                    case 5:
                        pos = (numDigits % 4) + 1;
                        if (number.Substring(0, 2) != "00")
                            place = " Thousand ";

                        break;
                    case 6:
                        pos = (numDigits % 6) + 1;
                        if (number.Substring(0, 1) != "0")
                            place = " Lac ";
                        break;
                    case 7://Lac's range
                        pos = (numDigits % 6) + 1;
                        if (number.Substring(0, 1) != "000")
                            place = " Lac ";
                        break;
                    case 8:

                    case 9:

                        pos = (numDigits % 8) + 1;

                        place = " Crore ";

                        break;

                    case 10://Billions's range

                        pos = (numDigits % 10) + 1;

                        place = " Billion ";

                        break;

                    //add extra case options for anything above Billion...

                    default:

                        isDone = true;

                        break;

                }

                if (!isDone)
                {//if transalation is not done, continue...(Recursion comes in now!!)

                    word = translateWholeNumber(number.Substring(0, pos)) + place + translateWholeNumber(number.Substring(pos));

                    //check for trailing zeros

                    //if (beginsZero) word = " and " + word.Trim();

                }

                //ignore digit grouping names

                if (word.Trim().Equals(place.Trim())) word = "";

            }

        }

        catch { ;}

        return word.Trim();

    }

    private String tens(String digit)
    {

        int digt = Convert.ToInt32(digit);

        String name = null;

        switch (digt)
        {

            case 10:

                name = "Ten";

                break;

            case 11:

                name = "Eleven";

                break;

            case 12:

                name = "Twelve";

                break;

            case 13:

                name = "Thirteen";

                break;

            case 14:

                name = "Fourteen";

                break;

            case 15:

                name = "Fifteen";

                break;

            case 16:

                name = "Sixteen";

                break;

            case 17:

                name = "Seventeen";

                break;

            case 18:

                name = "Eighteen";

                break;

            case 19:

                name = "Nineteen";

                break;

            case 20:

                name = "Twenty";

                break;

            case 30:

                name = "Thirty";

                break;

            case 40:

                name = "Fourty";

                break;

            case 50:

                name = "Fifty";

                break;

            case 60:

                name = "Sixty";

                break;

            case 70:

                name = "Seventy";

                break;

            case 80:

                name = "Eighty";

                break;

            case 90:

                name = "Ninety";

                break;

            default:

                if (digt > 0)
                {

                    name = tens(digit.Substring(0, 1) + "0") + " " + ones(digit.Substring(1));

                }

                break;

        }

        return name;

    }

    private String ones(String digit)
    {

        int digt = Convert.ToInt32(digit);

        String name = "";

        switch (digt)
        {

            case 1:

                name = "One";

                break;

            case 2:

                name = "Two";

                break;

            case 3:

                name = "Three";

                break;

            case 4:

                name = "Four";

                break;

            case 5:

                name = "Five";

                break;

            case 6:

                name = "Six";

                break;

            case 7:

                name = "Seven";

                break;

            case 8:

                name = "Eight";

                break;

            case 9:

                name = "Nine";

                break;

        }

        return name;

    }

    private String translateCents(String cents)
    {

        String cts = "", digit = "", engOne = "";

        for (int i = 0; i < cents.Length; i++)
        {

            digit = cents[i].ToString();

            if (digit.Equals("0"))
            {

                engOne = "Zero";

            }

            else
            {

                engOne = ones(digit);

            }

            cts += " " + engOne;

        }

        return cts;

    }

}
