// No JS
document.querySelector('body').classList.remove('no-js');
document.querySelector('body').classList.add('js');

// Scroll events

//var plan = {
//	element: document.querySelector('.plan'),
//	hasAnimated: false,
//	class: 'animation'
//};

//if (plan.element !== null) {
//	window.addEventListener('scroll', function () {
//		if (!plan.hasAnimated) {
//			var position = plan.element.getBoundingClientRect();

//			console.log(position.top);

//			if (position.top >= 0 && position.bottom <= window.innerHeight) {
//				plan.hasAnimated = true;
//				plan.element.classList.add(plan.class);
//			}

//			if (position.top < window.innerHeight && position.bottom >= 0) {
//				plan.hasAnimated = true;
//				plan.element.classList.add(plan.class);
//			}
//		}
//	});
//}

var menu = {
    button: document.querySelector('.menu'),
    class: 'active',
    target: document.querySelector('header'),
    bodyClass: 'navigation-active',
    body: document.querySelector('body')
};
if (menu.button !== null && menu.target !== null) {
    menu.button.addEventListener('click', () => {
        if (menu.target.classList.contains(menu.class)) {
            menu.target.classList.remove(menu.class);
            menu.body.classList.remove(menu.bodyClass);
        }
        else {
            menu.target.classList.add(menu.class);
            menu.body.classList.add(menu.bodyClass);
        }
    });
}

var smoothScrolls = {
    elements: document.querySelectorAll('[data-smooth-scroll]')
};
if (smoothScrolls.elements.length) {
    smoothScrolls.elements.forEach(x => {
        x.addEventListener('click', (e) => {
            e.preventDefault();
            var target = x.getAttribute('href');
            window.history.replaceState(null, null, target);
            document.querySelector(target).scrollIntoView({
                behavior: 'smooth'
            });
        });
    });
}

var modals = {
    elements: document.querySelectorAll('[data-modal="True"]'),
    modal: {
        root: document.querySelector('.modal'),
        title: document.querySelector('.modal .title'),
        postTitle: document.querySelector('.modal .post-title'),
        content: document.querySelector('.modal .text'),
        link: document.querySelector('.modal .link'),
        class: 'active',
        close: document.querySelector('.modal .close')
    }
};

if (modals.elements.length && modals.modal.title !== null) {
    modals.elements.forEach(x => {
        x.addEventListener('click', (e) => {
            e.preventDefault();

            var title = x.getAttribute('data-modal-title');
            var content = x.getAttribute('data-modal-content');
            var link = x.getAttribute('data-modal-link');
            var linkText = x.getAttribute('data-modal-link-text');
            var postTitle = x.getAttribute('data-modal-post-title');

            modals.modal.title.innerHTML = title;
            modals.modal.content.innerHTML = content;

            if (postTitle !== "") {
                modals.modal.postTitle.innerHTML = postTitle;
            }
            
            if (link !== "") {
                modals.modal.link.setAttribute('href', link);
                modals.modal.link.innerHTML = linkText;
                modals.modal.link.style = "display: table;";
            }

            modals.modal.root.classList.add(modals.modal.class);

        });
    });

    if (modals.modal.close !== null) {
        modals.modal.close.addEventListener('click', (e) => {
            e.preventDefault();
            modals.modal.root.classList.remove(modals.modal.class);
        });
    }

    document.addEventListener('keyup', (e) => {
        if (e.key === "Escape" && modals.modal.root.classList.contains(modals.modal.class)) {
            modals.modal.root.classList.remove(modals.modal.class);
        }
    });
}