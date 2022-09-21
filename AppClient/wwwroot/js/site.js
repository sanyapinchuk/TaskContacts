document.querySelector("#arrow_up").onclick = function(){
    window.scrollTo(top);
}

window.addEventListener('scroll', function() {
    let arraw = this.document.getElementById('arrow_up');
    if (pageYOffset > 172)
    {
        arraw.style.opacity = '0.7';
    }  
    if (pageYOffset < 172) {
        arraw.style.opacity = '0';
    } 
});

let addInfoBlocks = document.getElementsByClassName('add_info_block');
let moreButtons = document.getElementsByClassName('more');
let lessButtons = document.getElementsByClassName('less');

for(let i =0; i < moreButtons.length; i++){
    moreButtons[i].addEventListener('click',(evt)=>
    {
        addInfoBlocks[i].style.display= 'block';
        lessButtons[i].style.visibility= 'visible';
        moreButtons[i].style.visibility= 'hidden';	
    })    
}
for(let i =0; i < lessButtons.length; i++){
    lessButtons[i].addEventListener('click',(evt)=>
    {
        addInfoBlocks[i].style.display= 'none';
        lessButtons[i].style.visibility= 'hidden';
        moreButtons[i].style.visibility= 'visible';	
    })
}
