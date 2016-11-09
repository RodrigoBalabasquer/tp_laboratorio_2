using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;
using Archivos;
using Trabajo_Practico_N_3;


namespace Test_Unitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

        }
        /// <summary>
        /// Test unitario que revisa que todos los atributos de las clases, no esten en null.
        /// </summary>
        [TestMethod]
        public void GimanasioCorrecto()
        {
            Gimnasio gim = new Gimnasio();

            Assert.IsNotNull(gim.Alumno);
            Assert.IsNotNull(gim.Instructor);
            Assert.IsNotNull(gim.Jornada);

            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit,
            Alumno.EEstadoCuenta.MesPrueba);
            Assert.IsNotNull(a1.Apellido);
            Assert.IsNotNull(a1.Nombre);
            Assert.IsNotNull(a1.Nacionalidad);
            Assert.IsNotNull(a1.DNI);

            Instructor i1 = new Instructor(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Assert.IsNotNull(i1.Apellido);
            Assert.IsNotNull(i1.Nombre);
            Assert.IsNotNull(i1.Nacionalidad);
            Assert.IsNotNull(i1.DNI);

        }
        /// <summary>
        /// Verifica que si se ingresa un dni que no es valido con su nacionalidad,
        /// lanze una excepcion.
        /// </summary>
        [TestMethod]
        public void NacionalidadCorrecta()
        {
            try
            {
                Alumno AlumArg = new Alumno(1, "Juan", "Lopez", "9125468",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit,
                Alumno.EEstadoCuenta.MesPrueba);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
            try
            {
                Alumno AlumExtrang = new Alumno(1, "Juan", "Lopez", "7125468",
                EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Gimnasio.EClases.CrossFit,
                Alumno.EEstadoCuenta.MesPrueba);

            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
        /// <summary>
        /// Verifica que si se ingresa un alumno que contenga el mismo dni que otro que ya este en la
        /// lista, lanze una excepcion.
        /// </summary>
        [TestMethod]
        public void MismoAlumno()
        {
            Gimnasio gim = new Gimnasio();
            Alumno A1 = new Alumno(1, "Juan", "Lopez", "7125468",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit,
            Alumno.EEstadoCuenta.MesPrueba);
            Alumno A2 = new Alumno(2, "Pedro", "Lopez", "7125468",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.Natacion,
            Alumno.EEstadoCuenta.MesPrueba);
            gim += A1;
            try
            {
                gim += A2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }
        /// <summary>
        /// Verifica que el dni que ingresemos tenga el mismo valor numerico del atributo.
        /// </summary>
        [TestMethod]
        public void CargarDni()
        {
            Alumno AlumArg = new Alumno(1, "Juan", "Lopez", "7125468",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit,
            Alumno.EEstadoCuenta.MesPrueba);
            Assert.AreEqual(AlumArg.DNI, 7125468);
        }
    }
}