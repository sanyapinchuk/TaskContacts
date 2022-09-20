
  jQuery.validator.addMethod( 
    "phoneNumber",   
    function(phone_number, element) {
          phone_number = phone_number.replace(/\s+/g, "");
          return this.optional(element) || phone_number.length > 9 && 
              phone_number.match(/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})$/);
    }, 
    "Введите корректный номер телефона");

jQuery.validator.addMethod(
  "dateVal", 
  function(date_validator, element) {
        date_validator = date_validator.replace(/\s+/g, "");
        return this.optional(element) || date_validator.length > 9 && 
            date_validator.match(/^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$/);
  }, 
"введите дату в формате дд.мм.гггг");

$(function() {
    $("#order-form").validate({
        rules: {
            Name: { 
                required:true,
                minlength: 2,
                maxlength: 150
            },
            MobilePhone: {
                required: true,
                phoneNumber: true,
                minlength: 6,
                maxlength: 18
            },
            JobTitle: {
                required: false,
                maxlength: 150
            },
            BirthDate: {
                required: false,
                dateVal: true
            }
            
        },
        messages: {
          Name: {
              required:"Пожалуйста, введите новое имя контакта",
              minlength: "Минимальная длина имени 1 символ",
              maxlength: "Длина имени не должна превышать 150 символов"
          },
          MobilePhone: {
              required: "Пожалуйста, введите новый номер контакта",
              phoneNumber: "формат номера +******* / ******",
              minlength: "Минимальная длина номера 6 цифр",
              maxlength: "Максимальная длина номера 18 символов",
          },
          JobTitle: {
              maxlength: "Длина должности не должна превышать 150 символов"
          },
          BirthDate: {
              dateVal: "формат даты дд.мм.гггг"
          }
        },
        submitHandler: function(form) { 
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
                    //console.log("success");
                    location.reload();
                }
            });
            return false;
        }
        
    });
});