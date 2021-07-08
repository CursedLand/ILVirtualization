# 🎈 ILVirtualization [![MIT license](https://img.shields.io/badge/License-MIT-blue.svg)](https://lbesson.mit-license.org/)
.NET Virtualizer Made By [CursedLand](https://github.com/CursedLand/).

# 🎀 What does this do
This convert .NET ByteCode (aka CIL) into New Set Of Instructions Which Only Understandable By ILVirtualization Runtime.

# 🎲 Know Clues
- Some Handlers Have Simple Mistakes. (i.e Ldelem_R8, Call, Callvirt, Newobj).
- No Support For Pointer CilOpCodes. (i.e Ldelema, Ldsflda, Ldloca).
- No Support For Exception Handlers.
- Not All Handlers well Tested.
- This Also May Lead to a Noticeable Performance Hit(s).
- Xor is Weak Algorithm.

# 🧩 What This Made For ?
- Protecting Very Important And Sensitive Codes. (i.e License Checking Code, API Connections).
- Protecting Code That Implements Algorithms.

# 🔬 Resources
- https://en.wikipedia.org/wiki/List_of_CIL_instructions
- https://www.ecma-international.org/wp-content/uploads/ECMA-335_6th_edition_june_2012.pdf
- https://docs.microsoft.com/en-us/dotnet/api/system.reflection.emit.opcodes?view=net-5.0

# 🔮 Credits
- [AsmResolver](https://github.com/Washi1337/AsmResolver/)
