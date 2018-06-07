# GLUWP

GLUWP (pronounced "gloop") strives to be just enough code to allow running OpenGL (GLES2) code on Microsoft's Universal
Windows Platform in C#. It is comprised of a direct port of [the template project for Microsoft's fork of
ANGLE](https://github.com/Microsoft/angle/tree/ms-master/templates/10/Windows/Universal/XamlUniversal), and a handful of
classes that expose an API that mimics [OpenTK](https://github.com/opentk/opentk)'s OpenGL bindings. The bindings are
far from complete, but they were enough to get my simple app working (they cover the basics: textures, shaders, vertex
buffers and draw calls). UWP does not include an OpenGL implementation, so GLUWP references [Microsoft's ANGLE for
UWP](https://github.com/Microsoft/angle) [packages](https://www.nuget.org/packages/ANGLE.WindowsStore) as its OpenGL
implementation.

## Getting Started

The `SampleApp` project should work out of the box, and is easy enough to follow that it should be enough to get you
going. Alternatively you can instantiate a `GLView` object and add a responder to its `Draw` event to call your
rendering code. `GLView` derives from `SwapChainPanel`, a standard UWP control, so you should be able to just drop it in
pretty much anywhere in your UI. At present there are no Nuget packages available, so I would probably just copy the
GLWUP project into your solution.

## License

GLUWP is licensed under the BSD License. See [LICENSE.md](LICENSE.md) for details.

## Authors

See [AUTHORS.md](AUTHORS.md) for a complete list of contributors.

## Contributing

If you would like to contribute code, please follow these simple guidelines:

* Try to match the style of the files you are changing.
* In your first PR, please add yourself to the [AUTHORS.md](AUTHORS.md) file, and understand that you are making your
  changes available under the same BSD licensing terms as the rest of GLUWP.
* If you're adding bindings (which would be extremely welcome!), please remember to add them to both GL.cs *and*
  GLDebug.cs, and only add bindings if you have code that calls them and you have verified that they work.
* Please strive to retain (or improve) compatibility with the OpenTK API.

## Debugging

In addition to the simple OpenGL bindings, there is also a debug class that exposes the same API as the GL class and
forwards calls through, but also calls `glGetError` after each call. If an error is found, it will invoke
`Debugger.Break()` which should break into the debugger right after the error occurred. If you have a bug in your code
(or suspect a bug in GLUWP), as a first step I recommend changing

```
using GLUWP.ES20;
```

to

```
using GLUWP.ES20Debug;
```

This will enable this debug functionality for all the GL calls made in that file. Personally I have both variants in my
code guarded by an `ifdef` so that I can switch between them with a build configuration. At some point I would love to
extend this functionality to expose a more powerful GL debugger, with frame capture and command traces, etc.

## API

The API of GLUWP should not be considered stable, however changes to it will generally aim to increase its compatibility
with OpenTK's API.

## A Few Random Thoughts

Whilst I hope that you find this software useful, I also hope that it becomes unnecessary in the near future. GLUWP was
borne of necessity: I had a C# OpenGL application that worked on a variety of other platforms, but the lack of GL
bindings for C# on UWP prevented me from adding UWP to my list of supported platforms. I initially started by trying to
port OpenTK to UWP, but OpenTK is pretty big and porting it quickly proved non-trivial (I suspect there is a good reason
the OpenTK team have not done this port themselves). It also didn't contain the magical incantation to setup the GL
viewport in the UI (eye of newt and toe of frog, object of SwapChainPanel and surface of ANGLE, etc), which is the least
well understood (by me) part of the whole affair.

I figured that for the subset of OpenGL I was using, it probably wouldn't take more than about an afternoon to author
those bindings myself, and with enough judicious googling I was eventually able to figure out the incantation to bring
up a view on which to render. Despite being API compatible(ish) with OpenTK, this is not just a copy and paste of
OpenTK's code -- I just took my existing OpenTK based application, and kept adding stuff until it compiled. I've tried
to leave things such that if you have OpenTK code for another platform, it should only be a couple of `using` lines that
need to be changed. Specifically, whilst the names of enums will be pretty similar to OpenTK, the values of the
constants were taken by hand from ANGLE's header file. This was likely an unnecessary precaution, but the last thing I
wanted to be spending time on was debugging errors stemming from constants that weren't consistent across
implementations.

Long story short: GLUWP isn't the most elegant solution I could imagine to this problem, but you can get it now and
start using it straight away. If the bindings it exposes are enough for you (or almost enough, and you're comfortable
adding bindings yourself), then using it is probably not a bad way to go. However, if you have a codebase that uses a
very large subset of OpenGL, I'd give serious consideration to attempting the task I baulked at: extending OpenTK to
support UWP, perhaps using some of this code to facilitate that.
