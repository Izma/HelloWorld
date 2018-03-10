Vue.use(VeeValidate);
var persons = new Vue({
    el: '#persons',
    data: {
        persons: []
    },
    created: function () {
        this.$http.get('/person/GetPersons').then(function (response) {
            this.persons = response.body;
        }, function () {
            alert('Error!');
        });
    }
});


new Vue({
    el: '#form',
    data: {
        message: '',
        form: {
            name: '',
            lastName: '',
            age: null,
            opinion: '',
            genre: null,
            userRegister: ''
        }
    }, methods: {
        onSubmit: function () {
            this.$http.post('/person/savePerson', this.form).then(function (response) {
                this.message = response.body;
                if (this.message === 'success') {
                    this.form = {};
                    $('#modal-new-register').modal('hide');
                    console.log(persons.$root);
                }

            }, function () {
                alert('Error!');
            });
        }
    }
});

$(document).ready(() => {
    $('#new-register').click((event) => {
        $('#modal-new-register').modal({
            backdrop: 'static',
            show: true,
            keyboard: false
        });
    });
});