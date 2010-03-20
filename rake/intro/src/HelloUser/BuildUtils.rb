require 'rubygems'
require 'find'
require 'zip/zip'
require 'fileutils'

class NUnitRunner
	include FileTest

	def initialize(paths)
		@resultsDir = paths.fetch(:results, 'results')
		@compileTarget = paths.fetch(:compilemode, 'debug')
		
		@nunitExe = File.join('lib', 'nunit', "nunit-console.exe").gsub('/','\\') + ' /nothread'
	end
	
	def executeTests(assemblies)
		Dir.mkdir @resultsDir unless exists?(@resultsDir)
		
		assemblies.each do |assem|
			file = File.expand_path("#{assem}/bin/#{@compileTarget}/#{assem}.dll")
			sh "#{@nunitExe} \"#{file}\""
		end
	end
end

class MSBuildRunner
	def self.compile(attributes)
		version = attributes.fetch(:clrversion, 'v3.5')
		compileTarget = attributes.fetch(:compilemode, 'debug')
	    solutionFile = attributes[:solutionfile]
		
		frameworkDir = File.join(ENV['windir'].dup, 'Microsoft.NET', 'Framework', version)
		msbuildFile = File.join(frameworkDir, 'msbuild.exe')
		
		sh "#{msbuildFile} #{solutionFile} /maxcpucount /v:m /property:BuildInParallel=false /property:Configuration=#{compileTarget} /t:Rebuild"
	end
end

def create_zip(filename, root, excludes=/^$/)
  File.delete(filename) if File.exists? filename
  Zip::ZipFile.open(filename, Zip::ZipFile::CREATE) do |zip|
    Find.find(root) do |path|
	  next if path =~ excludes
	  
	  zip_path = path.gsub(root, '')
	  zip.add(zip_path, path)
	end
  end
end