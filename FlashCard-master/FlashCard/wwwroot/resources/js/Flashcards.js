const cards = document.querySelectorAll('.cardfc');

function transition() {
  if (this.classList.contains('activecard')) {
    this.classList.remove('activecard');
  } else {
    this.classList.add('activecard');
  }
}

cards.forEach(card => card.addEventListener('click', transition));

var slideIndex = 1;
showDivs(slideIndex);

function plusDivs(n) {
  showDivs(slideIndex += n);
}

function showDivs(n) {
  var i;
  var x = document.getElementsByClassName("slides");
  if (n > x.length) {slideIndex = 1}    
  if (n < 1) {slideIndex = x.length}
  for (i = 0; i < x.length; i++) {
     x[i].style.display = "none";  
  }
  x[slideIndex-1].style.display = "block";  
  document.getElementsByClassName("pagination")[0].innerText = slideIndex + ' / ' + x.length;
}

function showActionBtn(n) {
  for (i = 1; i <= n; i++) {
    var x = document.getElementById("btn-action" + i);
    if (window.getComputedStyle(x, null).display === "none") {
      x.style.display = "block";
    } else {
      x.style.display = "none";
    }
  }
}

/*** Tooltips ***/
$(document).ready(function(){
  $('[rel="tooltip"]').tooltip({trigger: "hover"});
});
