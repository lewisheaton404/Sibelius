document.getElementById('burger-menu').addEventListener('click', () => {
    var targetClass = "active",
        element = document.getElementById('burger-menu'),
        navigation = document.getElementById('navigation'),
        isToggledOn = element.classList.contains(targetClass),
        body = document.querySelector('body');

    if (isToggledOn) {
        element.classList.remove(targetClass);
        navigation.classList.remove(targetClass);
        body.classList.remove('nav-active');
    }
    else {
        element.classList.add(targetClass);
        navigation.classList.add(targetClass);
        body.classList.add('nav-active');
    }
});

var childClass = document.getElementsByClassName('more');

for (let i = 0; i < childClass.length; i++) {
    childClass[i].addEventListener("click", function () {
        var targetClass = "active",
            element = childClass[i];
            isToggledOn = element.classList.contains(targetClass);

        if (isToggledOn) {
            element.classList.remove(targetClass);
        }
        else {
            element.classList.add(targetClass);
        }
    })
}