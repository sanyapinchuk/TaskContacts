$(function() {
   // $('.error').hide();
    $("#sendForm").click(function() {
      // validate and process form here
      /*
      $('.error').hide();
  	  var name = $("input#name").val();
  		if (name == "") {
        $("label#name_error").show();
        $("input#name").focus();
        return false;
      }
  		var email = $("input#email").val();
  		if (email == "") {
        $("label#email_error").show();
        $("input#email").focus();
        return false;
      }
  		var phone = $("input#phone").val();
  		if (phone == "") {
        $("label#phone_error").show();
        $("input#phone").focus();
        return false;
      }*/
      var id = $("input#form_input_id").val();
      var name = $("input#form_input_name").val();
      var phone = $("input#form_input_phone").val();
      var birth = $("input#form_input_birth").val();
      var job = $("input#form_input_job").val();
      var dataString = 'Id=' + id + '&Name='+ name + '&MobilePhone=' + phone + '&JobTitle=' + job + '&BirthDate=' + birth;
        //alert (dataString);return false;
        $.ajax({
            type: "PUT",
            url: "https://localhost:7241/api/Contact/edit",
            data: dataString,
            success: function() {
            location.reload();
            }
        });
        return false;
    });
  });
