const cards = document.querySelectorAll(".card");
const closeButton = document.querySelectorAll(".right");
const body = document.body;

cards.forEach(element => {
    element.addEventListener("click", function (e) {
      element.classList.toggle('grow')
   
        body.classList.toggle('overlay');
        body.classList.toggle('is-open');
    });
});
closeButton.forEach(element => {
    element.addEventListener("click", function (e) {
        element.removeEventListener('click', () => {
            element.parentElement.parentElement.parentElement.classList.toggle('grow')
           
            body.classList.toggle('overlay');
            body.classList.toggle('is-open');
        })
    });
});