
[TOC]


# GeneratePathProperty
	
	<ItemDefinitionGroup>
		<!-- We always want MSBuild properties generated that point at the restored location of each package. -->
		<PackageReference GeneratePathProperty="true" />
	</ItemDefinitionGroup>

<PackageReference GeneratePathProperty="true" /> 是一个用来在项目文件中指定 NuGet 包引用的元素，它可以让你在 MSBuild 中获取包的安装路径¹²。它的作用是为了方便在项目中使用包中的一些工具或文件，例如执行某个可执行文件，或者覆盖某个引用³。它的语法如下：

XML
<PackageReference Include="Some.Package" Version="1.0.0" GeneratePathProperty="true" />

这样，你就可以在 MSBuild 中使用 $(PkgSome_Package) 变量来表示包的安装路径，其中包名中的点会被替换成下划线¹²。注意 Pkg 前缀。例如，你可以在项目文件中添加如下内容：

XML
<Target Name="TakeAction" AfterTargets="Build">
  <Exec Command="$(PkgSome_Package)\something.exe" />
</Target>

这样，每次构建后，都会执行 Some.Package 包中的 something.exe 文件¹²。

源: 与必应的对话， 2023/10/20
(1) NuGet PackageReference in project files | Microsoft Learn. https://learn.microsoft.com/en-us/nuget/consume-packages/package-references-in-project-files.
(2) 项目文件中的 NuGet PackageReference | Microsoft Learn. https://learn.microsoft.com/zh-cn/nuget/consume-packages/package-references-in-project-files.
(3) A Better Way to Override References With PackageReference. https://duanenewman.net/blog/post/a-better-way-to-override-references-with-packagereference/.
(4) Get NuGet package folder in MSBuild - Stack Overflow. https://stackoverflow.com/questions/11705650/get-nuget-package-folder-in-msbuild.

# AdditionalFiles

	<ItemGroup Condition="Exists('$(MSBuildThisFileDirectory)stylecop.json')">
		<AdditionalFiles  Include="$(MSBuildThisFileDirectory)stylecop.json" Link="stylecop.json" />
	</ItemGroup>

<AdditionalFiles 是一个用于指定项目中的附加文件的标签，它可以将一些非源代码文件作为输入传递给编译器或分析器。附加文件可以用于提供一些配置信息，词典，样本数据等，以便在编译时或运行时使用。以下是一些关于 <AdditionalFiles 的网页搜索结果：

- [C# Incremental Generator - How I can read additional files ...](^1^)：这是一个关于如何在 C# 增量生成器中使用 AdditionalTextsProvider 读取附加文件的 Stack Overflow 问题。
- [Build actions for files - Visual Studio (Windows) | Microsoft Learn](^2^)：这是一个关于如何在 Visual Studio 中设置文件的构建操作的文档，其中介绍了 AdditionalFiles 的作用和用法。
- [Additional files - BioMed Central](^3^)：这是一个关于如何在 BioMed Central 发表文章时提供附加文件的指南，其中说明了附加文件的定义和格式要求。
- [抽丝剥茧！Source Generators原理讲解 - 知乎 - 知乎专栏](^4^)：这是一个关于 C# 源代码生成器原理和实现的知乎专栏文章，其中提到了如何使用 AdditionalFiles 获取项目中的配置文件。
- [Introduction - GitHub: Let’s build from here](^5^)：这是一个关于如何在 Roslyn 分析器中使用附加文件的 GitHub 文档，其中给出了一些示例和说明。

源: 与必应的对话， 2023/10/20
(1) C# Incremental Generator - How I can read additional files .... https://stackoverflow.com/questions/72095200/c-sharp-incremental-generator-how-i-can-read-additional-files-additionaltexts.
(2) Build actions for files - Visual Studio (Windows) | Microsoft Learn. https://learn.microsoft.com/en-us/visualstudio/ide/build-actions?view=vs-2022.
(3) Additional files - BioMed Central. https://www.biomedcentral.com/getpublished/writing-resources/additional-files.
(4) 抽丝剥茧！Source Generators原理讲解 - 知乎 - 知乎专栏. https://zhuanlan.zhihu.com/p/430728295.
(5) Introduction - GitHub: Let’s build from here. https://github.com/dotnet/roslyn/blob/main/docs/analyzers/Using%20Additional%20Files.md.