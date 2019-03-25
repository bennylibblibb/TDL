<%
pyear=year(date())
pmonth=month(date())
%>
<%
function checknumber(number1,number2)
if number1=number2 then
response.write " selected"
end if
end function%>

<P>
<FONT FACE="Verdana, Arial" SIZE=2>
<FORM ACTION="<% =sScript%>" METHOD=GET>
<SELECT NAME=MONTH>
<OPTION VALUE=1 <%checknumber pmonth,1%>>1Month
<OPTION VALUE=2 <%checknumber pmonth,2%>>2Month
<OPTION VALUE=3 <%checknumber pmonth,3%>>3Month
<OPTION VALUE=4 <%checknumber pmonth,4%>>4Month
<OPTION VALUE=5 <%checknumber pmonth,5%>>5Month
<OPTION VALUE=6 <%checknumber pmonth,6%>>6Month
<OPTION VALUE=7 <%checknumber pmonth,7%>>7Month
<OPTION VALUE=8 <%checknumber pmonth,8%>>8Month
<OPTION VALUE=9 <%checknumber pmonth,9%>>9Month
<OPTION VALUE=10 <%checknumber pmonth,10%>>10Month
<OPTION VALUE=11 <%checknumber pmonth,11%>>11Month
<OPTION VALUE=12 <%checknumber pmonth,12%>>12Month
</SELECT>
<SELECT NAME=YEAR>
<OPTION VALUE=1999 <%checknumber pyear,1999%>>1999
<OPTION VALUE=2000 <%checknumber pyear,2000%>>2000
<OPTION VALUE=2001 <%checknumber pyear,2001%>>2001
<OPTION VALUE=2002 <%checknumber pyear,2002%>>2002
<OPTION VALUE=2003 <%checknumber pyear,2003%>>2003
</SELECT>
</FONT>
<P><INPUT TYPE="Image" NAME="" SRC="images/go.gif" BORDER="0" WIDTH="35" HEIGHT="20"></P>
</FORM>


