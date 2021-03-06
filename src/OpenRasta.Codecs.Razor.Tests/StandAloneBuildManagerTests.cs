﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using NUnit.Framework;

namespace OpenRasta.Codecs.Razor.Tests
{
    [TestFixture]
    public class CompilationManagerTests
    {
        [Test]
        public void Valid_code_is_compiled_to_a_class()
        {
            IBuildManager manager = new StandAloneBuildManager(new FakeViewProvider(@"@resource System.String
@System.DateTime.Now"));
            var type = manager.GetCompiledType("ViewFile.cshtml");
            Assert.IsNotNull(type);
        }

        [Test]
        public void Invalid_code_causes_exception_to_be_thrown()
        {
            IBuildManager manager = new StandAloneBuildManager(new FakeViewProvider(@"@resource System.String
@System.DateTime.Now2"));
            Assert.Throws<HttpCompileException>(() => manager.GetCompiledType("ViewFile.cshtml"));
        }
    }
}
