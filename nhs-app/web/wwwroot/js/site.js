// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

document.addEventListener('DOMContentLoaded', () => {
   const elements = document.querySelectorAll('.modal')
    
    const options = {
       opacity: 1
       
    }
    const instances = M.Modal.init(elements, options)
})

