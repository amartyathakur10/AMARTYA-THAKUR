        function add()
        {
        var a= document.getElementById("number1").value;
        var b=document.getElementById("number2").value;
        var results=parseInt(a)+parseInt(b);
        document.getElementById("results").value=results;
        }

        function sub()
        {
        var a= document.getElementById("number1").value;
        var b=document.getElementById("number2").value;
        var results=parseInt(a)-parseInt(b);
        document.getElementById("results").value=results;
        }

        function divide()
        {
        var a= document.getElementById("number1").value;
        var b=document.getElementById("number2").value;
        var results=parseInt(a)/parseInt(b);
        document.getElementById("results").value=results;
        }

        function multiply()
        {
        var a= document.getElementById("number1").value;
        var b=document.getElementById("number2").value;
        var results=parseInt(a)*parseInt(b);
        document.getElementById("results").value=results;
        }

        function cleartext()
        {
            document.getElementById("results").value="";
            document.getElementById("number1").value="";
            document.getElementById("number2").value="";
        }