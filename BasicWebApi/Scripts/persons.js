$(document).ready(function () {
    
    $("#phonebook").html("Coś tam");

    $.ajax({
        method : "GET",
        url: "/api/Person",
        cache: false
    })
        .done(function (data) {
            //alert(data[1].Name);
            console.log(JSON.stringify(data));
            $("#phonebook").append("<table>");
            $("#phonebook").append("<tr><td>ID</td><td>Name</td><td>Organization</td></tr>");
            for (i = 0; i < data.length; i++) {
                $("#phonebook").append("<tr>");
                $("#phonebook").append("<td>" + data[i].ID+"</td>");
                $("#phonebook").append("<td>" + data[i].Name+"</td>");
                $("#phonebook").append("<td>" + data[i].Organization + "</td>");
                $("#phonebook").append("<td> <button id='btn_" + i + "' onclick='details(" + i + ")' >  Details</button> </td>");
                $("#phonebook").append("<td> <button id='btn_e" + i + "' class='edit_btn' >  Edit</button> </td>");
                $("#phonebook").append("</tr>");
            }
            $("#phonebook").append("</table>");
            $(".edit_btn").click(function () {
                console.log("Kliknięto klawisz o id" + this.id);
                var id = this.id.substring(5);
                window.location.href = "/api/Person/" + id;
            });
        });
})


function details(id) {
    window.location.href="/api/Person/" + id;
}