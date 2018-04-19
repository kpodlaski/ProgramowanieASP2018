var person = {
    'ID': -1,
    'Name': "",
    'Organization': "",
    'Phones' : []
};
$(document).ready(function () {
    $("#btn_submit").click(function (event) {
        person.Name = $("#name").val();
        person.Organization = $("#org").val();
        var ph = {
            'ID': 12,
            'Number': $("#tel").val()
        }
        person.Phones[0] = ph;
        console.log(JSON.stringify(person));
        event.preventDefault();
        $.ajax({
            method: "POST",
            url: "/api/Person",
            data: person,
            dataType: 'json'
        }).done(function () {
            window.location.href = "/Persons";
        }).fail(function () {
            alert("error");
        })
    });

});