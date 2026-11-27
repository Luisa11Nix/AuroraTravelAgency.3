// JavaScript del lado del cliente de Aurora Travel Agency
document.addEventListener('DOMContentLoaded', function () {
    document.body.classList.add('js-ready');

    // 1. Animación de aparición al hacer scroll
    const elementos = document.querySelectorAll('.reveal');
    if ('IntersectionObserver' in window) {
        const observador = new IntersectionObserver(function (entradas) {
            entradas.forEach(function (entrada) {
                if (entrada.isIntersecting) {
                    entrada.target.classList.add('visible');
                    observador.unobserve(entrada.target);
                }
            });
        }, { threshold: 0.15 });
        elementos.forEach(function (el) { observador.observe(el); });
    } else {
        elementos.forEach(function (el) { el.classList.add('visible'); });
    }

    // 2. Contador de caracteres del campo "Comentarios" (formulario de cotización)
    const comentarios = document.getElementById('Comentarios');
    const contador = document.getElementById('contadorComentarios');
    if (comentarios && contador) {
        const actualizar = function () { contador.textContent = comentarios.value.length; };
        comentarios.addEventListener('input', actualizar);
        actualizar();
    }

    // 3. Aviso de descuento para grupos de 4 o más viajeros
    const viajeros = document.getElementById('NumeroViajeros');
    const aviso = document.getElementById('avisoGrupo');
    if (viajeros && aviso) {
        const revisar = function () {
            aviso.classList.toggle('d-none', parseInt(viajeros.value, 10) < 4 || isNaN(parseInt(viajeros.value, 10)));
        };
        viajeros.addEventListener('input', revisar);
        revisar();
    }

});
