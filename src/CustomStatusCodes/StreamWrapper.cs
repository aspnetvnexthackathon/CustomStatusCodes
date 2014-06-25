using System;
using System.IO;
using Microsoft.AspNet.Http;

namespace CustomStatusCodes
{
    public class StreamWrapper : Stream
    {
        private bool started = false;
        private Stream innerStream;
        private Func<HttpContext, bool> inspectStatusCode;
        private HttpContext context;

        public StreamWrapper(Stream innerStream, Func<HttpContext, bool> inspectStatusCode, HttpContext context)
        {
            this.innerStream = innerStream;
            this.inspectStatusCode = inspectStatusCode;
            this.context = context;
        }

        public override bool CanRead
        {
            get { return innerStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return innerStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return innerStream.CanWrite; }
        }

        public override long Length
        {
            get { return innerStream.Length; }
        }

        public override long Position
        {
            get
            {
                return innerStream.Position;
            }
            set
            {
                innerStream.Position = value;
            }
        }

        private void OnFirstWrite()
        {
            if (!started)
            {
                started = true;
                if (inspectStatusCode(context))
                {
                    // Suppress writes, we're going to replace the stream body with a Kitten.
                    innerStream = Stream.Null;
                }
            }
        }

        public override void Flush()
        {
            OnFirstWrite();
            innerStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return innerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            innerStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            OnFirstWrite();
            innerStream.Write(buffer, offset, count);
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            OnFirstWrite();
            return innerStream.BeginWrite(buffer, offset, count, callback, state);
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            innerStream.EndWrite(asyncResult);
        }

        public override System.Threading.Tasks.Task WriteAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken)
        {
            OnFirstWrite();
            return innerStream.WriteAsync(buffer, offset, count, cancellationToken);
        }
    }
}
