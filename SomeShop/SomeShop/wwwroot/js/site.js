$(function () {

    if ($("a.confirmDeletion").length) {
        $("a.confirmDeletion").click(() => {
            if (!confirm("Confirm deletion")) return false;
        });
    }

    if ($("div.alert.notification").length) {
        setTimeout(() => {
            $("div.alert.notification").fadeOut();
        }, 2000);
    }

});

function readURL(input) {
    if (input.files && input.files[0]) {
        let reader = new FileReader();

        reader.onload = function (e) {
            $("img#imgpreview").attr("src", e.target.result).width(200).height(200);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

const random = (min, max) => {
    const rand = min + Math.random() * (max - min + 1);
    return Math.floor(rand);
}

let btn1 = document.querySelector('#btn1');
btn1.addEventListener('mouseenter', () => {
    btn1.style.left = `${random(0, 90)}%`;
    btn1.style.top = `${random(0, 90)}%`;
})

