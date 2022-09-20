let editBtns = document.getElementsByClassName('contact_edit');
for(let i=0; i<editBtns.length; i++){
  editBtns[i].addEventListener('click',(evt)=>{
    //show popup
    let elem = document.getElementById('pop-order');
    elem.style.visibility= 'visible';	
    let elem2 = document.getElementById('body');
    elem2.style.opacity = '0.4';
    document.body.style.overflow = 'hidden';

    //fill date
    let id = document.getElementsByClassName('contact_id')[i];
    let name = document.getElementsByClassName('contact_name')[i];
    let phone = document.getElementsByClassName('contact_phone')[i];
    let job = document.getElementsByClassName('contact_job')[i];
    let birth = document.getElementsByClassName('contact_birth')[i];

    document.getElementById('form_input_id').value = id.innerHTML;
    document.getElementById('form_input_name').value = name.innerHTML;
    document.getElementById('form_input_phone').value  = phone.innerHTML;
    document.getElementById('form_input_job').value  = job.innerHTML;
    document.getElementById('form_input_birth').value  = birth.innerHTML;

    let form = document.getElementById('order-form');
    form.setAttribute('data-action-url','https://localhost:7241/api/Contact/edit');
    form.setAttribute('data-method-type','PUT');
    //form.dataset.actionUrl = 'https://localhost:7241/api/Contact/edit';
    //form.methodType = 'PUT';
    document.getElementById('span').innerHTML = 'Изменить контакт';
    document.getElementById('sendForm').innerHTML = 'Изменить';
  })
}

let deleteBtns = document.getElementsByClassName('contact_delete');
for(let i=0; i<deleteBtns.length; i++){
  deleteBtns[i].addEventListener('click',(evt)=>{
    var goDelete = confirm("Удалить выбранный контакт?");
    if(goDelete){
      let id = document.getElementsByClassName('contact_id')[i].innerHTML;
      $.ajax({
        type: "DELETE",
        url: "https://localhost:7241/api/Contact/delete/"+id,
        data: "",
        success: function() {
            //console.log("success");
            location.reload();
        }
    });
    }
  })
}

document.querySelector("#addContact").onclick = function(){
    //show popup
    let elem = document.getElementById('pop-order');
    elem.style.visibility= 'visible';	
    let elem2 = document.getElementById('body');
    elem2.style.opacity = '0.4';
    document.body.style.overflow = 'hidden';

    document.getElementById('form_input_id').value = "aa8e2ea1-7ecd-47fe-8791-a2741a25cf48"; //any guid
    document.getElementById('form_input_name').value = "";
    document.getElementById('form_input_phone').value  = "";
    document.getElementById('form_input_job').value  = "";
    document.getElementById('form_input_birth').value  = "";

    let form = document.getElementById('order-form');
    form.setAttribute('data-action-url','https://localhost:7241/api/Contact/create');
    form.setAttribute('data-method-type','POST');

    document.getElementById('span').innerHTML = 'Добавить контакт';
    document.getElementById('sendForm').innerHTML = 'Добавить';
  }


document.querySelector("#order-all").onclick = function(){
    let elem = document.getElementById('pop-order');
    elem.style.visibility= 'hidden';	
    let elem2 = document.getElementById('body');
      elem2.style.opacity = '1';
    document.body.style.overflow = 'visible';		
}

document.querySelector("#icon-close").onclick = function(){
  let elem = document.getElementById('pop-order');
  elem.style.visibility= 'hidden';	
  let elem2 = document.getElementById('body');
    elem2.style.opacity = '1';
  document.body.style.overflow = 'visible';		
}