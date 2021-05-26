<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectSix.calender.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
    <link href="<%=Page.ResolveClientUrl("~/main-assets/fullcalendar/lib/main.css")%>" rel='stylesheet' />
    
    
     <script>

         function my_fun() {

             var dt = document.getElementById('<%=hf_day.ClientID %>').value;

             getmenu(dt);

         }
         function my_js_function() {

             my_fun();

         }

     </script>

    <script>
        function popup() {
            swal({
                title: "Successful!",
                text: "Your Booking is Successful.",
                icon: "success",
                button: "Ok",
            });
        }
        function popupduplicatedata() {
            swal({
                title: "Server Error!",
                text: "Your Booking is already exists!",
                icon: "error",
                button: "Ok",
            });
        }
    </script>
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="maincontent" runat="server">

    <section class="wow fadeIn cover-background background-position-top top-space" id="header_img" runat="server">
        <div class="opacity-medium bg-extra-dark-gray"></div>
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-sm-12 col-xs-12 display-table page-title-large">
                    <div class="display-table-cell vertical-align-middle text-center padding-30px-tb">
                        <!-- start sub title -->

                        <!-- end sub title -->
                        <!-- start page title -->
                        <h1 class="alt-font text-white font-weight-600 no-margin-bottom">Book Your Appointment</h1>
                        <!-- end page title -->
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section class="wow fadeIn" style="background: url(../main-asstes/images/bg_4.jpg) no-repeat center top;">

        <div class="container">
            <div class="row text-center">
                <div class="col-md-12 col-sm-12 col-xs-12 display-table wow slideInRight last-paragraph-no-margin sm-text-center margin-50px-bottom" style="visibility: visible; animation-name: slideInRight; height: 71px;">
                    <div class=" xs-text-center">

                        <h4 class="alt-font text-extra-dark-gray text-center ">Book Your Appointment</h4>

                    </div>
                </div>
                <div class="clearfix"></div>

                  <div class="col-md-6 col-md-offset-3">
                            <div id='calendar'></div>
                            </div>
            </div>
        </div>
    </section>

       <!-- Modal -->
                        <div class="popupouter">
                            <div class="popupinner">
                                <span class="closeit">x</span>
                                <!-- Modal content-->
                                <div class="popup-content">
                                    <h2>Appointment</h2>
                                    <%-- <form>--%>
                                    <p class="popspcl"><b>Date: </b><span class="dateonly">20-03-2020</span></p>

                                    <%--<p class="popspcl"><b>Day: </b><span class="dayonly" id="txt_day" runat="server">Sunday</span></p> --%>

                                    <p class="popspcl pricetag"><b>Price:</b><span id="price" runat="server"></span> <%-- $2000.00--%></p>


                                    <div class="checkbox-outer row">
                                        <p class="popspcl col-md-12"><b>Select Time Slot:</b></p>
                                        <div class="col-md-12" id="timeslot_list" runat="server">
                                            <%--<div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox1">
                                                <label class="form-check-label" for="inlineCheckbox1">10:00AM - 12:00PM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox2">
                                                <label class="form-check-label" for="inlineCheckbox2">12:00PM - 02:00PM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox3">
                                                <label class="form-check-label" for="inlineCheckbox3">02:00PM - 04:00PM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox4">
                                                <label class="form-check-label" for="inlineCheckbox4">04:00PM - 06:00PM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox5">
                                                <label class="form-check-label" for="inlineCheckbox5">06:00PM - 08:00PM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox6">
                                                <label class="form-check-label" for="inlineCheckbox6">08:00PM - 10:00PM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox7">
                                                <label class="form-check-label" for="inlineCheckbox7">10:00PM - 12:00AM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox8">
                                                <label class="form-check-label" for="inlineCheckbox8">11:00AM - 02:00AM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox9">
                                                <label class="form-check-label" for="inlineCheckbox9">02:00AM - 04:00AM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox10">
                                                <label class="form-check-label" for="inlineCheckbox10">04:00AM - 06:00AM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox11">
                                                <label class="form-check-label" for="inlineCheckbox11">06:00AM - 08:00AM</label>
                                            </div>
                                            <div class="form-check col-md-6">
                                                <input class="form-check-input" type="checkbox" id="inlineCheckbox12">
                                                <label class="form-check-label" for="inlineCheckbox12">08:00AM - 10:00AM</label>
                                            </div>--%>
                                        </div>
                                    </div>
                                    <div class="form-group popmsg">
                                        <label>Type Your Message here</label>
                                        <textarea class="form-control" rows="3" placeholder="Type here..." id="txt_desc" runat="server"></textarea>
                                    </div>
                                    <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" class="btn btn-primary" Text="Submit"  />
                                    <%--<input type="submit" name="" value="Submit"  class="btn btn-primary submitbutton" id="btnSave" runat="server"  önclick="ShowAlert();">--%>
                                    <%-- </form>--%>
                                </div>

                            </div>
                        </div>

    <section class="bg-light-gray wow fadeIn hover-option4 blog-post-style3">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 center-col margin-five-bottom sm-margin-40px-bottom xs-margin-30px-bottom text-center">

                    <h5 class="alt-font text-extra-dark-gray font-weight-600 width-65 margin-lr-auto md-width-85 xs-width-100">Image Voting</h5>
                </div>
            </div>
            <div class="row equalize xs-equalize-auto" id="voting_list" runat="server">
            </div>
        </div>
    </section>
    
      <asp:HiddenField ID="hf_date" runat="server" Value="" />
    <asp:HiddenField ID="hf_checkbox" runat="server" Value="" />
    <asp:HiddenField ID="hf_price" Value="" runat="server" />
    <asp:HiddenField ID="hf_day" Value="" runat="server" />
    <asp:HiddenField ID="hf_DTLS_APPOINTMENT_KEY" Value="" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
    </asp:ScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
    
    <script src="<%=Page.ResolveClientUrl("~/main-assets/fullcalendar/lib/main.js")%>"></script>
    <script src="<%=Page.ResolveClientUrl("~/main-assets/js/nicescroll.js")%>"></script>

       <script>
           $(document).ready(function () {
               getall();

               $(".fc-day").click(function () {
                   $(".popupouter").show("");
               });

               $(".closeit").click(function () {
                   $(".popupouter").hide("");
               });

               //$(".popup-content").niceScroll({
               //    cursorcolor: "#cccccc",
               //    cursorwidth: "3px",
               //    background: "#3a3843",
               //    cursorborder: "0px solid #eee",
               //    cursorborderradius: 2
               //});

               var calendarEl = document.getElementById('calendar');
               var calendar = new FullCalendar.Calendar(calendarEl, {
                   initialView: 'dayGridMonth'
               });
               calendar.render();
           });

       </script>
    <script>
        var mydata;
        var arr;
        var total = 0;

        function getall() {
            $.ajax({
                url: '<%=ResolveUrl("~/calender/index.aspx/GetAllEvent") %>',

                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "",
                success: function (data) {
                    mydata = JSON.parse(data.d);
                    var vString = "";
                    if (mydata == null) {
                        alert("Sorry!! This is an offday! No Timeslot available today!!");
                    }
                    else {
                        mydata = JSON.parse(data.d);
                        console.log(mydata);
                        //for (var i = 0; i < mydata.length - 1; i++) {
                        //    var obj = mydata[i];
                        //}

                        var calendarEl = document.getElementById('calendar');
                        var calendar = new FullCalendar.Calendar(calendarEl, {
                            selectable: true,
                            initialView: 'dayGridMonth',
                            //initialDate: '2021-03-07',
                            defaultDate: new Date(),
                            timeZone: 'local',
                            editable: true,
                            headerToolbar: {
                                left: 'prev,next today',
                                center: 'title',
                                right: 'dayGridMonth,timeGridWeek,timeGridDay'
                            },

                            dateClick: function (info) {
                                //debugger;
                                //alert('Date: ' + info.date.getDay());

                                var day = info.date.getDay();
                                document.getElementById('<%=hf_day.ClientID %>').value = day;
                                document.getElementById('<%=hf_date.ClientID %>').value = info.dateStr;
                                //alert(info.isToday);
                                //document.getElementById('dateonly').innerHTML = info.dateStr;
                                my_js_function();
                                $(".popupouter").show("");
                                $(".popspcl .dateonly").text(info.dateStr);

                            },

                            events: mydata,

                        });
                        var cdate = calendar.getDate();
                        var month_int = cdate.getMonth();
                        calendar.render();
                    }

                },

                error: function (response) {
                    console.log(response.responseText);
                },
                failure: function (response) {
                    console.log(response.responseText);
                }
            });



        }

        function getmenu(MenuName) {
            //debugger;
            //$("#inputMenuName").val("");
            //alert('ok');
            $.ajax({
                url: '<%=ResolveUrl("~/calender/index.aspx/GetEvent") %>',

                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: "{date1: '" + MenuName + "'}",
                success: function (data) {
                    mydata = JSON.parse(data.d);
                    //console.log(mydata["PRICE"]);
                    var vString = "";
                    if (mydata == null) {

                        //document.getElementById("time").innerHTML = "<p>Sorry!! This is an offday! No Timeslot available today!!</p>";
                        alert("Sorry!! This is an offday! No Timeslot available today!!");

                    }
                    else {
                        //alert("Sorry!!! some error occured");
                        //alert(data.d);
                        mydata = JSON.parse(data.d);
                        for (var i = 0; i < mydata.length - 1; i++) {
                            var obj = mydata[i];
                            document.getElementById("maincontent_price").innerHTML = obj.PRICE;

                            vString += "<div class='form-check col-md-6'><input class='form-check-input' type ='checkbox' name='my_match[]' value='190' onclick='checkboxcheck(this)'  id = '" + obj.DTLS_TIMETABLE_KEY + "'>";
                            vString += "<label class='form-check-label' for='inlineCheckbox" + i + "'>" + obj.START_TIME + " - " + obj.END_TIME + "</label></div >";


                        }

                        document.getElementById("maincontent_timeslot_list").innerHTML = vString;
                        document.getElementById('<%=hf_checkbox.ClientID %>').value = obj.DTLS_TIMETABLE_KEY;
                    }

                },

                error: function (response) {
                    console.log(response.responseText);
                },
                failure: function (response) {
                    console.log(response.responseText);
                }
            });
        }
        function checkboxcheck(e) {
            //debugger;
            //console.log(e);
            var bid;
            var obj;
            for (let i in mydata) {

                var d = mydata[i];
                if (d.DTLS_TIMETABLE_KEY == e.id) {
                    obj = d;
                }
            }

            if (e.checked == true) {
                console.log(e.checked);
                total += obj.PRICE;
                if (arr === undefined)
                    arr = ',' + obj.DTLS_TIMETABLE_KEY;
                else
                    arr = arr + "," + obj.DTLS_TIMETABLE_KEY;

                console.log(arr);
            } else {
                console.log(e.checked);
                total -= obj.PRICE;
                arr = arr.replace(',' + obj.DTLS_TIMETABLE_KEY, '');
                console.log(arr);
            }

            document.getElementById("maincontent_price").innerHTML = total;
            document.getElementById('<%=hf_price.ClientID %>').value = total;
            document.getElementById('<%=hf_checkbox.ClientID %>').value = arr;

        }



    </script>
    <script>
        function get() {
            var dt = document.getElementById('<%=hf_date.ClientID %>').value;
        }
    </script>


</asp:Content>
